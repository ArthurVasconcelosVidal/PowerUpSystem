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
    

    public delegate void ButtonPerformed(InputAction.CallbackContext buttonContext);
    public ButtonPerformed southButtonPerformed, westButtonPerformed, northButtonPerformed, eastButtonPerformed;

    void Start() {
        SetUpGameAction();
        InputManager.EnableInputAsset(InputManager.MainPlayerInput);
        //inputManager.MainPlayerInput.GameAction.Disable(); //Disable some action in input actions
    }

    void SetUpGameAction(){
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

        InputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => southButtonPerformed(contextMenu);

        InputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => westButtonPerformed(contextMenu);

        InputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => northButtonPerformed(contextMenu);

        InputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => eastButtonPerformed(contextMenu);
    }

}
