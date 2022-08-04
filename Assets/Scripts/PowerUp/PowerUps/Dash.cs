using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour, IPressReleaseAction{
    [SerializeField] InputActionManager playerInput;

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => DashAction();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => Debug.Log("Fisnish");

    void DashAction(){
        Debug.Log("Funcionando");
    }


    void OnEnable() {
        playerInput.OnWestButtonPerformed += OnButtonPressed;
        playerInput.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnWestButtonPerformed -= OnButtonPressed;
        playerInput.OnWestButtonCanceled -= OnButtonReleased;
    }
}
