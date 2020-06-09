using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscSkeletonSender : MonoBehaviour
{
    public int oscPort = 55555;
    public bool pause = false;
    public nuitrack.JointType[] typeJoint;
    public bool sendAsBulk = true;
    SharpOSC.UDPSender sender;

    void Start()
    {
        sender = new SharpOSC.UDPSender("127.0.0.1", oscPort);

        if (sendAsBulk)
        {
            StartCoroutine(SendOscBulk());
        }
        else
        {
            StartCoroutine(SendOsc());
        }
    }

    private IEnumerator SendOsc()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (CurrentUserTracker.CurrentUser != 0)
            {
                nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;
                for (int q = 0; q < typeJoint.Length; q++)
                {
                    nuitrack.Joint joint = skeleton.GetJoint(typeJoint[q]);
                    Vector3 newPosition = 0.001f * joint.ToVector3();
                    String m = String.Format("/{0}", 0, joint.Type);
                    if (!pause)
                    {
                        SharpOSC.OscMessage message = new SharpOSC.OscMessage(m, newPosition.x, newPosition.y, newPosition.z);
                        //Debug.Log(String.Format("/{0}/{1}/{2}/{3}", m, rj.bone.position.x, rj.bone.position.y, rj.bone.position.z));
                        sender.Send(message);
                    }
                }
             }
        }
    }

    private IEnumerator SendOscBulk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (CurrentUserTracker.CurrentUser != 0)
            {
                nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;
                float[] floats = new float[] { };
                List<float> jointList = new List<float>();

                for (int q = 0; q < typeJoint.Length; q++)
                {
                    nuitrack.Joint joint = skeleton.GetJoint(typeJoint[q]);
                    Vector3 newPosition = 0.001f * joint.ToVector3();
                    jointList.Add(newPosition.x);
                    jointList.Add(newPosition.y);
                    jointList.Add(newPosition.z);
                }

                object[] objects = jointList.Cast<object>().ToArray();

                if(objects.Length > 0 && !pause)
                {
                    SharpOSC.OscMessage message = new SharpOSC.OscMessage("/wek/inputs", objects);
                    sender.Send(message);
                }
            }
        }
    }
}
