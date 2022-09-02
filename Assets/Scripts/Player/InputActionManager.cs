using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour{
    InputManager InputManager { get {return InputManager.instance;} }
    [Header("Stick values (DEBUG)")]
    [SerializeField] Vector2 rightStick;
    [SerializeField] Vector2 leftStick;
    public Vector2 RightStickValue { get { return rightStick; } }
    public Vector2 LeftStickValue { get { return leftStick; } }

    [Header("Active Buttons")]
    public bool southButtonActive; 
    public bool westButtonActive;
    public bool northButtonActive;
    public bool eastButtonActive;
    public bool rightStickActive;
    public bool leftStickActive;
    public bool rightShoulderActive;
    public bool leftShoulderActive;
    public bool rightTriggerActive;
    public bool leftTriggerActive; 

    public event EventHandler<InputAction.CallbackContext> 
    OnSouthSecondaryButtonPerformed, OnSouthPrimaryButtonPerformed, OnWestButtonPerformed, OnNorthButtonPerformed, OnEastPrimaryButtonPerformed,OnEastSecondaryButtonPerformed, OnRightShoulderButtonPerformed, OnLeftShoulderButtonPerformed, OnRightTriggerButtonPerformed, OnLeftTriggerButtonPerformed,
    OnSouthSecondaryButtonCanceled, OnSouthPrimaryButtonCanceled, OnWestButtonCanceled, OnNorthButtonCanceled, OnEastPrimaryButtonCanceled,OnEastSecondaryButtonCanceled, OnRightShoulderButtonCanceled, OnLeftShoulderButtonCanceled, OnRightTriggerButtonCanceled, OnLeftTriggerButtonCanceled;

    void Start() {
        StickConfig();
        ButtonsPerformedConfig();
        ButtonsCanceledConfig();
        InputManager.EnableInputAsset(InputManager.MainPlayerInput);
        //inputManager.MainPlayerInput.GameAction.Disable(); //Disable some action in input actions
    }

    void StickConfig(){
        InputManager.MainPlayerInput.GameAction.RightStick.performed += contextMenu => {
            if(rightStickActive) rightStick = contextMenu.ReadValue<Vector2>();
            else rightStick = Vector2.zero;
        };
        InputManager.MainPlayerInput.GameAction.RightStick.canceled += contextMenu => {
            rightStick = Vector2.zero;
        };

        InputManager.MainPlayerInput.GameAction.LeftStick.performed += contextMenu => {
            if(leftStickActive) leftStick = contextMenu.ReadValue<Vector2>();
            else leftStick = Vector2.zero;
        };
        InputManager.MainPlayerInput.GameAction.LeftStick.canceled += contextMenu => {
            leftStick = Vector2.zero;
        };
    } 

    void ButtonsPerformedConfig(){
        InputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => {
            if(southButtonActive){
                if(OnSouthPrimaryButtonPerformed != null){
                    OnSouthPrimaryButtonPerformed.Invoke(this, contextMenu);
                }
                else{
                    OnSouthSecondaryButtonPerformed?.Invoke(this, contextMenu);
                }
            }
        };

        InputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => { if(westButtonActive) OnWestButtonPerformed?.Invoke(this, contextMenu); };

        InputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => { if(northButtonActive) OnNorthButtonPerformed?.Invoke(this, contextMenu);};

        InputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => {
            if(eastButtonActive){
                if(OnEastPrimaryButtonPerformed != null){
                    OnEastPrimaryButtonPerformed.Invoke(this, contextMenu);
                }
                else{
                    OnEastSecondaryButtonPerformed?.Invoke(this, contextMenu);
                }
            }
        };

        InputManager.MainPlayerInput.GameAction.RightShoulder.performed += ContextMenu =>{ if(rightShoulderActive) OnRightShoulderButtonPerformed?.Invoke(this,ContextMenu);};

        InputManager.MainPlayerInput.GameAction.LeftShoulder.performed += ContextMenu =>{ if(leftShoulderActive) OnLeftShoulderButtonPerformed?.Invoke(this,ContextMenu);};

        InputManager.MainPlayerInput.GameAction.RightTrigger.performed += ContextMenu =>{ if(rightTriggerActive) OnRightTriggerButtonPerformed?.Invoke(this,ContextMenu);};
        
        InputManager.MainPlayerInput.GameAction.LeftTrigger.performed += ContextMenu =>{ if(leftTriggerActive) OnLeftTriggerButtonPerformed?.Invoke(this,ContextMenu);};
    }

    void ButtonsCanceledConfig(){
        InputManager.MainPlayerInput.GameAction.SouthButton.canceled += contextMenu => {
            if(southButtonActive){
                if(OnSouthPrimaryButtonPerformed != null)
                    OnSouthPrimaryButtonCanceled?.Invoke(this, contextMenu);
                else
                    OnSouthSecondaryButtonCanceled?.Invoke(this, contextMenu);
            }
        };

        InputManager.MainPlayerInput.GameAction.WestButton.canceled += contextMenu => { if(westButtonActive) OnWestButtonCanceled?.Invoke(this, contextMenu);};

        InputManager.MainPlayerInput.GameAction.NorthButton.canceled += contextMenu => { if(northButtonActive) OnNorthButtonCanceled?.Invoke(this, contextMenu);};

        InputManager.MainPlayerInput.GameAction.EastButton.canceled += contextMenu => {
            if(eastButtonActive){
                if(OnEastPrimaryButtonPerformed != null)
                    OnEastPrimaryButtonCanceled?.Invoke(this, contextMenu);
                else
                    OnEastSecondaryButtonCanceled?.Invoke(this, contextMenu);
            }
        };

        InputManager.MainPlayerInput.GameAction.RightShoulder.canceled += ContextMenu =>{ if(rightShoulderActive) OnRightShoulderButtonCanceled?.Invoke(this,ContextMenu);};

        InputManager.MainPlayerInput.GameAction.LeftShoulder.canceled += ContextMenu =>{ if(leftShoulderActive) OnLeftShoulderButtonCanceled?.Invoke(this,ContextMenu);};

        InputManager.MainPlayerInput.GameAction.RightTrigger.canceled += ContextMenu =>{ if(rightTriggerActive) OnRightTriggerButtonCanceled?.Invoke(this,ContextMenu);};

        InputManager.MainPlayerInput.GameAction.LeftTrigger.canceled += ContextMenu =>{ if(leftTriggerActive) OnLeftTriggerButtonCanceled?.Invoke(this,ContextMenu);};
    }

    public void EnableAllControlInputs(bool enable = true){
        EnableStickValues(enable);
        EnableActionButtons(enable);
        EnableDPad(enable);
        EnableBackButtons(enable);
    }

    public void EnableStickValues(bool enable = true){
        rightStickActive = enable;
        leftStickActive = enable;
    }
    public void EnableActionButtons(bool enable = true){
        eastButtonActive = enable;
        westButtonActive = enable;
        northButtonActive = enable;
        southButtonActive = enable;
    }
    public void EnableDPad(bool enable = true){
        //TODO: Implement if necessary
    }
    public void EnableBackButtons(bool enable = true){
        rightShoulderActive = enable;
        leftShoulderActive = enable;
        rightTriggerActive = enable;
        leftTriggerActive = enable;
    }
}
