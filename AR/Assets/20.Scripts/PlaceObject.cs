using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject marker;

    ARRaycastManager arRayManager;
    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }

    void DetectGround()
    {
        Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRayManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {

        }
    }
}
