using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleARCore;
using GoogleARCoreInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
// using System.Collections;

public class AugmentedImageVisualizer : MonoBehaviour
{
    public AugmentedImage Image;

    public GameObject Objeto;

    public void Start() 
    {
        // using System.Collections;
        // using System.Collections.Generic;
        // using UnityEngine;
        // using UnityEngine.SceneManagement;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

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
    
}
