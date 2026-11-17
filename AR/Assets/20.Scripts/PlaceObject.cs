using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject marker;
    public GameObject MyCar;

    ARRaycastManager arRayManager;
    List<GameObject> carList = new List<GameObject>();
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
            marker.SetActive(true);
            marker.transform.position = hits[0].pose.position;
        }
        else
        {
            marker.SetActive(false);
        }
    }

    public void PlaceCar()
    {
        if (!marker.activeSelf) return;
        GameObject go = Instantiate(MyCar, marker.transform.position, marker.transform.rotation);
        carList.Add(go);
    }

    public void RemoveLastCar()
    {
        int count = carList.Count;
        if (count == 0) return;

        GameObject go = carList[count - 1];
        Destroy(go);
        carList.RemoveAt(count - 1);
    }
}
