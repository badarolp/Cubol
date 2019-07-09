using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaceObject : MonoBehaviour {

    public GameObject Marker;

    public GameObject ObjectToPlace;

    Vector3 ScreenCenter;

    private bool IsObjectPlaced = false;

    // Use this for initialization
    void Start () {
        ScreenCenter = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update () {
        if (!IsObjectPlaced) {
            if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
                placeObjectAtMarker ();
            }
        }

    }

    [ContextMenu ("place")]
    private void placeObjectAtMarker () {
        ObjectToPlace.SetActive (true);
        Marker.SetActive (false);
        IsObjectPlaced = true;
    }

}