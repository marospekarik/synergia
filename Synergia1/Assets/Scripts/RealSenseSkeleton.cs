using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubemos
{
    /// <summary>
    /// Minimal sample demonstrating the use of Cubemos Skeleton Tracking with Intel Realsense D415/D435
    /// </summary>
    public class RealSenseSkeleton : MonoBehaviour
    {
        //private SkeletonTracker _skeletonTracker;
        //private RealsenseManager _realsense;
       // public List<Skeleton> lastSkeletons;
        private GameObject[] cubes;
        private GameObject obj;
        GameObject newJoint;
        GameObject sphere;
        void Start()
        {
            Debug.Log("Starting Cubemos Skeleton Tracking");
            // Initialise the cubemos skeleton tracking and intel realsense pipeline
           // _skeletonTracker = new SkeletonTracker();
           // _realsense = new RealsenseManager();

            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
           // _skeletonTracker.Initialize();
          //  _realsense.Initialize();
        }

        void Update()
        {
           // using (var frame = _realsense.GetFrame())
            //{
            //   lastSkeletons = _skeletonTracker.TrackSkeletonsWithRealsenseFrames(frame.ColorFrame,
                                                                                 //  frame.DepthFrame,
                                                                                //   _realsense.Intrinsics);
                // Debug.Log("Skeletons detected: " + lastSkeletons.Count);
            //    foreach (var sk in lastSkeletons)
              //  {
                 //   var sb = new System.Text.StringBuilder();
                    // sb.AppendLine("<b>Skeleton " + sk.Index + "</b>");
                //    foreach (var j in sk.Joints)
                //    {
                  //      string key = j.Key.ToString();
                 //       obj = GameObject.Find(key);
                 //       if (!obj)
                 //       {
                 //           newJoint = Instantiate(sphere, new Vector3(j.Value.position.x, j.Value.position.y, j.Value.position.z), Quaternion.identity);
                 //           newJoint.name = key;
                 //       }
                 //       else
                 //       {
                 //           obj.transform.position = new Vector3(j.Value.position.x, j.Value.position.y, j.Value.position.z);
                 //       }

                        //if (j.Key == 1)
                        // {
                        // cubes[j.Key].transform.Translate(j.Value.position.x, j.Value.position.y, j.Value.position.z);
                        // sb.AppendLine("Joint " + j.Key + ": " + j.Value.position + ", confidence: " + j.Value.confidence.ToString("F2"));
                        //}
               //     }
             //   }
        //    }
        }
    }
}