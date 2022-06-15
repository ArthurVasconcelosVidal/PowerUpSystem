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
    
    #region Button Delegates
    public delegate void SouthButtonBehaviour(InputAction.CallbackContext buttonContext);
    public SouthButtonBehaviour southButtonBehaviour;

    public delegate void WestButtonBehaviour(InputAction.CallbackContext buttonContext);
    public WestButtonBehaviour westButtonBehaviour;

    public delegate void NorthButtonBehaviour(InputAction.CallbackContext buttonContext);
    public NorthButtonBehaviour northButtonBehaviour;

    public delegate void EastButtonBehaviour(InputAction.CallbackContext buttonContext);
    public EastButtonBehaviour eastButtonBehaviour;
    
    #endregion

    private void Awake() {

    }

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

        InputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => southButtonBehaviour(contextMenu);

        InputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => westButtonBehaviour(contextMenu);

        InputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => northButtonBehaviour(contextMenu);

        InputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => eastButtonBehaviour(contextMenu);
    }

}
