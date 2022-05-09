using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{
    PlayerInput playerInput;

    [SerializeField] Vector2 rightStick;
    [SerializeField] Vector2 leftStick;

    public Vector2 RightStickValue { get { return rightStick; } }
    public Vector2 LeftStickValue { get { return leftStick; } }
    
    #region Button Delegates
    public delegate void SouthButtonBehaviour(InputAction.CallbackContext buttonContext);
    public SouthButtonBehaviour southButtonBehaviour;

    public delegate void WestButtonBehaviour(float buttonValue);
    public WestButtonBehaviour westButtonBehaviour;

    public delegate void NorthButtonBehaviour(float buttonValue);
    public NorthButtonBehaviour northButtonBehaviour;

    public delegate void EastButtonBehaviour(float buttonValue);
    public EastButtonBehaviour eastButtonBehaviour;
    
    #endregion

    private void Awake() {
        playerInput = new PlayerInput();

        SetUpPlayerActions();

    }

    void SetUpPlayerActions(){
        playerInput.PlayerActions.RightStick.performed += contextMenu => {
            rightStick = contextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.RightStick.canceled += contextMenu => {
            rightStick = Vector2.zero;
        };

        playerInput.PlayerActions.LeftStick.performed += contextMenu => {
            leftStick = contextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.LeftStick.canceled += contextMenu => {
            leftStick = Vector2.zero;
        };

        playerInput.PlayerActions.SouthButton.performed += contextMenu => {
            southButtonBehaviour(contextMenu);
        };

        playerInput.PlayerActions.WestButton.performed += contextMenu => {
            westButtonBehaviour(contextMenu.ReadValue<float>());
        };

        playerInput.PlayerActions.NorthButton.performed += contextMenu => {
            northButtonBehaviour(contextMenu.ReadValue<float>());
        };

        playerInput.PlayerActions.EastButton.performed += contextMenu => {
            eastButtonBehaviour(contextMenu.ReadValue<float>());
        };
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

}
