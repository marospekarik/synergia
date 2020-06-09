using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filtering : MonoBehaviour
{

    private GameObject obj1, obj2, obj3;
    private bool rotatingObj1 = false;
    private Vector3 rotationAxis1;
    private System.Random rnd = new System.Random();

    [Range(0.0f, 1.0f)]
    public float weight = 0.01f;

    Vector3 old_forward3, old_right3;
    bool firstFrame = true;

    void Start()
    {
        obj1 = GameObject.Find("original");
        obj2 = GameObject.Find("shaking");
        obj3 = GameObject.Find("smoothed");
    }

    void Update()
    {
        float currentTime = Time.time;

        // Set the orientation of obj1
        //
        int i = (int)currentTime;
        if (i % 2 == 1)
        { // During odd seconds ...
            if (!rotatingObj1)
            {
                // We are initiating a new rotation, so we choose a random axis of rotation
                rotatingObj1 = true;
                rotationAxis1 = new Vector3(2 * rnd.Next() - 1, 2 * rnd.Next() - 1, 2 * rnd.Next() - 1).normalized;
            }
            else
            { // ... we continue to rotate the object
                obj1.transform.rotation *= Quaternion.AngleAxis(2/*degrees*/, rotationAxis1);
            }
        }
        else rotatingObj1 = false;

        // Set the orientation of obj2
        //
        obj2.transform.rotation = obj1.transform.rotation;
        // Add a bit of noise to the orientation
        Vector3 rotationAxis2 = new Vector3(2 * rnd.Next() - 1, 2 * rnd.Next() - 1, 2 * rnd.Next() - 1).normalized;
        obj2.transform.rotation *= Quaternion.AngleAxis(10/*degrees*/, rotationAxis2);

        // Set the orientation of obj3
        //
        if (firstFrame)
        {
            // initialization
            old_forward3 = obj2.transform.forward;
            old_right3 = obj2.transform.right;
            firstFrame = false;
        }
        else
        {
            // obj3's orientation is a weighted average of obj2's current orientation and obj3's old orientation
            Vector3 new_forward3 = ((weight) * obj2.transform.forward + (1 - weight) * old_forward3).normalized;
            Vector3 new_right3 = ((weight) * obj2.transform.right + (1 - weight) * old_right3).normalized;

            // Use a cross-product to makes sure new_up3 is perpendicular to new_forward3.
            Vector3 new_up3 = Vector3.Cross(new_forward3, new_right3).normalized;

            obj3.transform.rotation = Quaternion.LookRotation(new_forward3, new_up3);

            old_forward3 = obj3.transform.forward;
            old_right3 = obj3.transform.right;
        }
    }
}