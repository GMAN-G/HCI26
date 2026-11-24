using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject obj1;
    public GameObject obj2;
    public TextMeshProUGUI debugText;

    ARTrackedImageManager imageManager;

    GameObject go1 = null;
    GameObject go2 = null;
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var image in imageManager.trackables)
        {
            debugText.text = $"Tracked: {image.referenceImage.name}";
            if (image.referenceImage.name == "myQR") { 
                if (go1 == null)
                {
                    go1 = Instantiate(obj1, image.transform.position, image.transform.rotation);
                }
                else
                {
                    go1.transform.position = image.transform.position;
                    go1.transform.rotation = image.transform.rotation;
                }
            }

            if (image.referenceImage.name == "namecard")
            {
                if (go2 == null)
                {
                    go2 = Instantiate(obj1, image.transform.position, image.transform.rotation);
                }
                else
                {
                    go2.transform.position = image.transform.position;
                    go2.transform.rotation = image.transform.rotation;
                }
            }
        }
    }
}
