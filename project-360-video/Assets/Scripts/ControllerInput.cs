using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class Controller : MonoBehaviour
{
    public InputActionReference activate;
    public NearFarInteractor interactor = null;
    [SerializeField]
    public GameObject TVScreen;
    private bool selected = false;

    void Start()
    {
        interactor.selectEntered.AddListener(OnSelect);
        interactor.selectExited.AddListener(OnExit);

        activate.action.performed += Use;
    }
    private void Use(CallbackContext callback)
    {
        if (!selected)
            return;

        print("USE PRESSED");
        var mat = TVScreen.GetComponent<Renderer>().material;
        if (mat.color == new Color(0, 0, 0))
        {
            mat.color = UnityEngine.Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
        }
        else
        {
            mat.color = new(0, 0, 0);
        }
    }

    private void OnExit(SelectExitEventArgs arg0)
    {
        selected = false;
    }


    private void OnSelect(SelectEnterEventArgs arg0)
    {
        print(arg0.interactableObject.transform.gameObject.name);

        if (arg0.interactableObject.transform.gameObject == gameObject) {
            selected = true;
        }
    }
}
