using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pC;
    ARFaceManager aFM;
    ARFace aF = null;
    int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        aFM = GetComponent<ARFaceManager>();
        pC.SetActive(false);

        aFM.trackablesChanged.AddListener(args => { foreach (var f in args.added) aF = f; foreach (var g in args.removed) if (g.Value == aF) aF = null;});
    }

    public void OnClick()
    {
        if (aF == null) return;
        if (aF.vertices.Length < 0) return;
        pC.SetActive(true);
        pC.transform.position = aF.transform.TransformPoint(aF.vertices[index]);
        index++;

        if (index >= aF.vertices.Length) index = 0;
    }
}
