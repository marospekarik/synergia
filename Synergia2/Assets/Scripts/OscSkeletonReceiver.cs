using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OscJack;
using Newtonsoft.Json;
using UnityEngine.UI;

class OscSkeletonReceiver : MonoBehaviour
{
    [SerializeField] GameObject jointPrefab = null;
    public int listenPort = 55555;
    public int sendPort = 7401;
    public string sendIp = "127.0.0.1";
    public bool shouldForwardData = false;
    public bool sendOscAsBulk = false;
    SharpOSC.UDPSender sender;
    OscServer server;
    public GameObject HMD;
    public int scale = 2;
    public Vector3 offset;
    Dictionary<JointType, Joint> joints = new Dictionary<JointType, Joint>();
    Dictionary<JointType, GameObject> jointsGame;
    Dictionary<JointType, GameObject> jointsDraw;
    JointSmooth JointSmoothL;
    JointSmooth JointSmoothR;
    public float weight = 1f;
    public bool recording = false;
    public InputField iField;

    public class DataLog
    {
        public long timestamp { get; set; }
        public string joint { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    List<DataLog> _data = new List<DataLog>();


    // --------------------------------------------------------------- Joint Class
    JointType[] jointsInfo = new JointType[]
{
        JointType.Head,
        JointType.Neck,
        JointType.RightShoulder,
        JointType.RightElbow,
        JointType.RightWrist,
        JointType.LeftShoulder,
        JointType.LeftElbow,
        JointType.LeftWrist,
        JointType.RightHip,
        JointType.RightKnee,
        JointType.RightAnkle,
        JointType.LeftHip,
        JointType.LeftKnee,
        JointType.LeftAnkle,
};
    public enum JointType
    {
        Head = 1,
        Neck = 2,
        RightShoulder = 3,
        RightElbow = 4,
        RightWrist = 5,
        LeftShoulder = 6,
        LeftElbow = 7,
        LeftWrist = 8,
        RightHip = 9,
        RightKnee = 10,
        RightAnkle = 11,
        LeftHip = 12,
        LeftKnee = 13,
        LeftAnkle = 14,
    }
    class Joint
    {
        public JointType Type { get; set; }
        public float Confidence { get; set; }
        public Vector3 Real { get; set; }
        public Vector3 Old { get; set; }
        public bool Pure { get; set; }
        public KalmanFilterVector3 Kalman { get; set; }
        public Vector3 Speed { get; set; }
        public Vector3 LastPos { get; set; }

        public Joint()
        {
            KalmanFilterVector3 kalm = new KalmanFilterVector3(0.8f, 1f);
            Kalman = kalm;
            LastPos = new Vector3(0, 0, 0);
            Pure = true;
        }
    }
    // --------------------------------------------------------------- Joint Class
    class JointSmooth
    {
        public Vector3 Real { get; set; }
        public Vector3 Old { get; set; }

        public JointSmooth()
        {
            Real = new Vector3(0,0,0);
            Old = new Vector3(0,0,0);
        }
    }

    void Start()
    {
        server = new OscServer(listenPort);
        sender = new SharpOSC.UDPSender(sendIp, sendPort);
        if (!jointPrefab) { jointPrefab = new GameObject(); }

        JointSmoothL = new JointSmooth();
        JointSmoothR = new JointSmooth();

        CreateSkeletonParts();
        CreateDrawParts();

        if (shouldForwardData) StartCoroutine(sendOscAsBulk ? SendOscBulk() : SendOscOut());

        server.MessageDispatcher.AddCallback(
            "", // OSC address
            (string address, OscDataHandle data) =>
            {
                float x = data.GetElementAsFloat(0);
                float y = data.GetElementAsFloat(1);
                float z = data.GetElementAsFloat(2);
                float confidence = data.GetElementAsFloat(3);
                string[] words = address.Split('/');
                int jointId = Int32.Parse(words[1]);
                if (jointId < 14)
                {
                    // Alternative smoothing solution
                    //Vector3 newPos = ((weight) * joints[jointsInfo[jointId]].Real + (1 - weight) * joints[jointsInfo[jointId]].Old);
                    //joints[jointsInfo[jointId]].Old = newPos;
                    var joint = joints[jointsInfo[jointId]];
                    joint.Confidence = confidence;
                    joint.Real = joint.Kalman.Update(new Vector3(x, y, z));
                    joint.Type = jointsInfo[jointId];
                    if (joint.Pure) joint.Pure = false;

                    //Debug.Log(string.Format("{0} | {1}, {2}, {3}, {4})", address, x, y, z, confidence));
                }
            }
        );
    }
    private void OnDestroy()
    {
        server.Dispose();
    }
    void Update()
    {
        Joint rightWrist = joints[jointsInfo[4]];
        rightWrist.Speed = rightWrist.Real - rightWrist.LastPos;
        rightWrist.Speed /= Time.deltaTime;
        rightWrist.LastPos = rightWrist.Real;

        if (!gameObject.activeSelf) gameObject.SetActive(true);
        for (int i = 0; i < jointsInfo.Length; i++)
        {
           ProcessSkeleton(i);
           DrawBody(i);
        }
    }

    void DrawBody(int i)
    {
        JointSmoothR.Real = jointsGame[jointsInfo[4]].transform.localPosition * scale + offset;
        JointSmoothL.Real = jointsGame[jointsInfo[7]].transform.localPosition * scale + offset;

        Vector3 newPosR = ((weight) * JointSmoothR.Real + (1 - weight) * JointSmoothR.Old);
        JointSmoothR.Old = newPosR;
        Vector3 newPosL = ((weight) * JointSmoothL.Real + (1 - weight) * JointSmoothL.Old);
        JointSmoothL.Old = newPosL;

        jointsDraw[jointsInfo[4]].transform.localPosition = JointSmoothR.Old;
        jointsDraw[jointsInfo[7]].transform.localPosition = JointSmoothL.Old;
        //jointsDraw[jointsInfo[i]].transform.localPosition = jointsGame[jointsInfo[i]].transform.localPosition * scale + offset;
    }

    void getAngle()
    {
        var wrist = jointsGame[jointsInfo[3]].transform;
        var elbow = jointsGame[jointsInfo[4]].transform;
        var angleY = Mathf.Asin(Vector3.Cross(wrist.forward, elbow.forward).y) * Mathf.Rad2Deg;
    }

    void ProcessSkeleton(int i)
    {
        Joint j = joints[jointsInfo[i]];
        //Quaternion.Euler(0f, 180f, 0f)
        if (!jointsGame[jointsInfo[i]].activeSelf) jointsGame[jointsInfo[i]].SetActive(true);
        if (j.Confidence > 0.1f)
        {
            Joint neck = joints[jointsInfo[1]];
            Vector3 rightHip = joints[jointsInfo[8]].Real;
            Vector3 leftHip = joints[jointsInfo[11]].Real;
            Vector3 middle = (rightHip + leftHip) / 2;

            // Parent
            transform.position = middle;

            //Child
            GameObject jT = jointsGame[jointsInfo[i]];
            Vector3 realWorldPos = j.Real;
            jT.transform.position = realWorldPos;

            Vector3 relativePoint = jT.transform.InverseTransformPoint(transform.position);
            jointsGame[jointsInfo[i]].transform.localPosition = relativePoint;
        }
    }

    void CreateSkeletonParts()
    {
        jointsGame = new Dictionary<JointType, GameObject>();

        for (int i = 0; i < jointsInfo.Length; i++)
        {
            joints.Add(jointsInfo[i], new Joint());
            GameObject myJoint = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
            jointsGame.Add(jointsInfo[i], myJoint);
            myJoint.name = jointsInfo[i].ToString();
            myJoint.transform.parent = transform;
            myJoint.SetActive(false);
        }
    }

    void CreateDrawParts()
    {
        jointsDraw = new Dictionary<JointType, GameObject>();

        for (int i = 0; i < jointsInfo.Length; i++)
        {
            GameObject comp = GameObject.Find(jointsInfo[i].ToString() + "Draw");
            JointType name = jointsInfo[i];
            if (comp)
            {
                jointsDraw.Add(jointsInfo[i], comp);
            }
            else
            {
                GameObject myJoint = Instantiate(jointPrefab ? jointPrefab : new GameObject(), Vector3.zero, Quaternion.identity);
                jointsDraw.Add(jointsInfo[i], myJoint);
                myJoint.name = jointsInfo[i].ToString() + "Draw";
                myJoint.transform.parent = transform;
                myJoint.SetActive(false);
            }
        }
    }

    public void OnButtonPress()
    {

        if(recording)
        {
            OnStopRecording();
        } else
        {
            OnStartRecording();
        }
    }

    void OnStartRecording()
    {
        recording = true;
    }

    void OnStopRecording()
    {
        recording = false;
        
        //Debug.Log(_data.ToArray());
        string json = JsonConvert.SerializeObject(_data.ToArray());

        //write string to file
        string fileName = iField.text;
        string name = String.Format(@"C:\Users\Bruger\Desktop\Synergia2\GestureRecognition\Data\Attract\{0}.json", fileName);
        System.IO.File.WriteAllText(name, json);
        _data.Clear();
        Debug.Log("Saved as " + fileName);
    }

    private IEnumerator SendOscOut()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < jointsInfo.Length; i++)
            {
                Transform jT = jointsGame[jointsInfo[i]].transform;
                Joint j = joints[jointsInfo[i]];
                float jX = jT.localPosition.x;
                float jY = jT.localPosition.y;
                float jZ = jT.localPosition.z;

                String m = String.Format("/{0}", jointsInfo[i]);
                SharpOSC.OscMessage message = new SharpOSC.OscMessage(m, jX, jY, jZ, j.Speed.magnitude);
                if(recording)
                {
                    long timeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    _data.Add(new DataLog()
                    {
                        timestamp = timeStamp,
                        joint = jointsInfo[i].ToString(),
                        x = jX,
                        y = jY,
                        z = jZ
                    });
                }
               
                sender.Send(message);
            }
        }

    }
    private IEnumerator SendOscBulk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            float[] floats = new float[] { };
            List<float> jointList = new List<float>();

            // for (int q = 0; q < jointsInfo.Length; q++)
            //  {
            //    Joint joint = joints[jointsInfo[q]];
            //    jointList.Add(jTRigth.localPosition.x);
            //    jointList.Add(jTRigth.localPosition.y);
            //    jointList.Add(jTRigth.localPosition.z);
            //}
            Transform jTRigth = jointsGame[jointsInfo[4]].transform;
            Transform jTLeft = jointsGame[jointsInfo[7]].transform;

            jointList.Add(jTRigth.localPosition.x);
            jointList.Add(jTRigth.localPosition.y);
            jointList.Add(jTRigth.localPosition.z);

            jointList.Add(jTLeft.localPosition.x);
            jointList.Add(jTLeft.localPosition.y);
            jointList.Add(jTLeft.localPosition.z);

            object[] objects = jointList.Cast<object>().ToArray();

            if (objects.Length > 0)
            {
                //SharpOSC.OscMessage message = new SharpOSC.OscMessage("/wek/inputs", objects);
                SharpOSC.OscMessage message = new SharpOSC.OscMessage("/RightWrist", jTRigth.localPosition.x, jTRigth.localPosition.y, jTRigth.localPosition.z);
                sender.Send(message);
            }
        }
    }
}
