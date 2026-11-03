using UnityEngine;

using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnFire(InputValue value)
    {
        anim.SetTrigger("IsFire");
    }
}
