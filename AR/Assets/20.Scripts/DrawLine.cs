using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLine : MonoBehaviour
{
    public LineSettings lineSetting;
    public Camera arCam;

    ARPlaneManager ARPlaneManager;
    bool initialized = false;
    bool canDraw = false;
    bool isStarting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.planesChanged += PlaneChanged;
    }

    void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(!initialized)
        {
            initialized = true;
        }
    }
    // Update is called once per frame

    public void AllowDraw(bool isAllow)
    {
        if (!initialized) return;

        canDraw = isAllow;
        if (canDraw) isStarting = true;
    }

    void DrawLines()
    {
        if (!canDraw) return;
    }

    void Update()
    {
        DrawLines();
    }
}
