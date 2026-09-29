using UnityEngine;
using UnityEngine.InputSystem;

public class CannonNewInput : MonoBehaviour
{
    public GameObject shellprefab;
    public Transform fireTrans;

    GameObject shell;

    void OnFire(InputValue value)
    {
        shell = Instantiate(shellprefab, fireTrans.position, fireTrans.rotation);
        //shell.GetComponent<Shellcontroller>().Shoot(fireTrans.up);
    }
}
