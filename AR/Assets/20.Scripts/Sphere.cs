using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class Sphere : MonoBehaviour
{
    public GameObject spherePrefab;
    private Camera arCamera;
    public Transform parentSphere;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject) return;
        var touchScreen = Touchscreen.current;
        if (touchScreen == null) return;
        if (!touchScreen.primaryTouch.press.wasPressedThisFrame) return;

        Vector2 screenPos = touchScreen.primaryTouch.position.ReadValue();
        Vector3 worldPos = arCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0.5f));
        GameObject go = Instantiate(spherePrefab, worldPos, Quaternion.identity);
        go.transform.parent = parentSphere;

        GameManager.instance.ShowMessage("Sphere");
    }

}
