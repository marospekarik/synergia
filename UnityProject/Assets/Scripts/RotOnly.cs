using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotOnly : MonoBehaviour
{
    private Vector3 InitialPos;
    private Vector3 hmdPos;
    public GameObject HMD;
    public Transform CameraPos;

    public Transform desiredHeadPosition;
    private Quaternion currRotationOffset;
    private Vector3 currPositionOffset;

    private GameObject head;
    void Start()
    {
        InitialPos = transform.position;
        head = GameObject.Find("Neck");
        StartCoroutine(CalculateOffset());
    }


    void LateUpdate()
    {
        //if (!head)
        // return;
        // float offsetAngle = HMD.transform.rotation.eulerAngles.y;

        //hmdPos = HMD.transform.localPosition;
        //transform.position = CameraPos.transform.position - hmdPos;

        //transform.Rotate(0f, -offsetAngle, 0f);

        //{now position}
        //calculate postional offset between CameraRig and Camera
        // Vector3 offsetPos = HMD.transform.position - transform.position;
        //reposition CameraRig to desired position minus offset
        //transform.position = (desiredHeadPosition.position - offsetPos);
    }
    public IEnumerator CalculateOffset()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

    }
}
