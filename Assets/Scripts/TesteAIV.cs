using GoogleARCore;
using GoogleARCoreInternal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class TesteAIV : MonoBehaviour
{
    public AugmentedImage Image;

    public GameObject Objeto;

    public void Update()
    {
        if (Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            Objeto.SetActive(false);
            return;
        }
        float halfWidth = Image.ExtentX / 2;
        float halfHeight = Image.ExtentZ / 2;
        Objeto.transform.localPosition = 30.0f * halfHeight * Vector3.forward;
        Objeto.SetActive(true);
    }

    /*
    public void Update()
    {
        if (Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            Objeto.SetActive(false);
            return;
        }
        Objeto.transform.localPosition = Image.CenterPose.position;
        Objeto.transform.localRotation = Image.CenterPose.rotation;
        Objeto.SetActive(true);
    }
    */



    /*
    public void Update()
    {
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else
            {
                // Choose the Andy model for the Trackable that got hit.
                GameObject prefab;
                if (hit.Trackable is FeaturePoint)
                {
                    prefab = AndyPointPrefab;
                }
                else if (hit.Trackable is DetectedPlane)
                {
                    DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                    if (detectedPlane.PlaneType == DetectedPlaneType.Vertical)
                    {
                        prefab = AndyVerticalPlanePrefab;
                    }
                    else
                    {
                        prefab = AndyHorizontalPlanePrefab;
                    }
                }
                else
                {
                    prefab = AndyHorizontalPlanePrefab;
                }

                // Instantiate Andy model at the hit pose.
                var andyObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);

                // Compensate for the hitPose rotation facing away from the raycast (i.e.
                // camera).
                andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

                // Create an anchor to allow ARCore to track the hitpoint as understanding of
                // the physical world evolves.
                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                // Make Andy model a child of the anchor.
                andyObject.transform.parent = anchor.transform;
            }
        }
    }
    */

}
