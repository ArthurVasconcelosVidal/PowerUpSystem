using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour{
    InputManager InputManager { get {return InputManager.instance;} }
    [SerializeField] Vector2 rightStick;
    [SerializeField] Vector2 leftStick;
    public Vector2 RightStickValue { get { return rightStick; } }
    public Vector2 LeftStickValue { get { return leftStick; } }
    [SerializeField] bool southButtonPrimary = false;

    public event EventHandler<InputAction.CallbackContext> 
    OnSouthSecondaryButtonPerformed, OnSouthPrimaryButtonPerformed, OnWestButtonPerformed, OnNorthButtonPerformed, OnEastButtonPerformed,
    OnSouthSecondaryButtonCanceled, OnSouthPrimaryButtonCanceled, OnWestButtonCanceled, OnNorthButtonCanceled, OnEastButtonCanceled;

    void Start() {
        StickConfig();
        ButtonsPerformedConfig();
        ButtonsCanceledConfig();
        InputManager.EnableInputAsset(InputManager.MainPlayerInput);
        //inputManager.MainPlayerInput.GameAction.Disable(); //Disable some action in input actions
    }

    void StickConfig(){
        InputManager.MainPlayerInput.GameAction.RightStick.performed += contextMenu => {
            rightStick = contextMenu.ReadValue<Vector2>();
        };
        InputManager.MainPlayerInput.GameAction.RightStick.canceled += contextMenu => {
            rightStick = Vector2.zero;
        };

        InputManager.MainPlayerInput.GameAction.LeftStick.performed += contextMenu => {
            leftStick = contextMenu.ReadValue<Vector2>();
        };
        InputManager.MainPlayerInput.GameAction.LeftStick.canceled += contextMenu => {
            leftStick = Vector2.zero;
        };
    } 

    void ButtonsPerformedConfig(){
        InputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => {
            if(OnSouthPrimaryButtonPerformed != null){
                OnSouthPrimaryButtonPerformed.Invoke(this, contextMenu);
                southButtonPrimary = true;
            }
            else{
                OnSouthSecondaryButtonPerformed?.Invoke(this, contextMenu);
                southButtonPrimary = false;
            }
        };

        InputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => OnWestButtonPerformed?.Invoke(this, contextMenu);

        InputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => OnNorthButtonPerformed?.Invoke(this, contextMenu);

        InputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => OnEastButtonPerformed?.Invoke(this, contextMenu);
    }

    void ButtonsCanceledConfig(){
        InputManager.MainPlayerInput.GameAction.SouthButton.canceled += contextMenu => {
            if(southButtonPrimary)
                OnSouthPrimaryButtonCanceled?.Invoke(this, contextMenu);
            else
                OnSouthSecondaryButtonCanceled?.Invoke(this, contextMenu);
        };

        InputManager.MainPlayerInput.GameAction.WestButton.canceled += contextMenu => OnWestButtonCanceled?.Invoke(this, contextMenu);

        InputManager.MainPlayerInput.GameAction.NorthButton.canceled += contextMenu => OnNorthButtonCanceled?.Invoke(this, contextMenu);

        InputManager.MainPlayerInput.GameAction.EastButton.canceled += contextMenu => OnEastButtonCanceled?.Invoke(this, contextMenu);
    }
}
