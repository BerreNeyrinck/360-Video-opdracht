using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputTest : MonoBehaviour
{
    public InputActionReference grip;
    public InputActionReference thumbStick;
    public InputActionReference activate;
    [SerializeField]
    public GameObject TVScreen;

    void Start()
    {
        grip.action.performed += Grip;
        thumbStick.action.performed += ThumbStick;
        activate.action.performed += Use;
    }
    private void Use(CallbackContext callback)
    {
        //print("USE PRESSED");
        //var mat = TVScreen.GetComponent<Renderer>().material;
        //if(mat.color == new Color(0, 0, 0))
        //{
        //    mat.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
        //}
        //else
        //{
        //    mat.color = new(0, 0, 0);
        //}
    }
    private void Grip(CallbackContext callback)
    {
        print("button pressed");
    }
    private void ThumbStick(CallbackContext obj)
    {
        Vector2 val = obj.ReadValue<Vector2>();
        print(val);
    }
}
