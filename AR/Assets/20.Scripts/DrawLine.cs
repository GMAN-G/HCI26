using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLine : MonoBehaviour
{
    public LineSettings lineSetting;
    public Camera arCam;

    Dictionary<int, ARLine> lines = new Dictionary<int, ARLine>();

    ARPlaneManager ARPlaneManager;
    bool initialized = false;
    bool canDraw = false;
    bool isStarting = false;
    int lineCount = -1;

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

        Vector3 drawPosition = arCam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0.2f));

        if (isStarting)
        {
            isStarting = false;
            ARLine line = new ARLine(lineSetting);
            lineCount++;
            lines.Add(lineCount, line);
            line.AddNewLineRenderer(transform, drawPosition);
            
        }
        else
        {
            lines[lineCount].AddPoint(drawPosition);
        }
    }

    void Update()
    {
        DrawLines();
    }
}
