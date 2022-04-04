using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    PlayerInput playerInput;

    [SerializeField] Vector2 rightStick;
    [SerializeField] Vector2 leftStick;

    public Vector2 RightStickValue { get { return rightStick; } }
    public Vector2 LeftStickValue { get { return leftStick; } }

    private void Awake() {
        playerInput = new PlayerInput();

        //Right Stick
        playerInput.PlayerActions.RightStick.performed += ContextMenu => {
            rightStick = ContextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.RightStick.canceled += ContextMenu => {
            rightStick = Vector2.zero;
        };

        //Left Stick
        playerInput.PlayerActions.LeftStick.performed += ContextMenu => {
            leftStick = ContextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.LeftStick.canceled += ContextMenu => {
            leftStick = Vector2.zero;
        };

        //Action Button
        playerInput.PlayerActions.ActionButton.performed += ContextMenu => {
            PlayerManager.instance.ActionManager.ActionButtonBehaviour();
        };         
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

}
