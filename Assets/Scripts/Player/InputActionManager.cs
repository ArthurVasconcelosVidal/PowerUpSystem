using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour{
    InputManager inputManager;
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
        inputManager = InputManager.instance;
        SetUpGameAction();
        inputManager.EnableInputAsset(inputManager.MainPlayerInput);
        //inputManager.MainPlayerInput.GameAction.Disable(); //Disable some action in input actions
    }

    void SetUpGameAction(){
        inputManager.MainPlayerInput.GameAction.RightStick.performed += contextMenu => {
            rightStick = contextMenu.ReadValue<Vector2>();
        };
        inputManager.MainPlayerInput.GameAction.RightStick.canceled += contextMenu => {
            rightStick = Vector2.zero;
        };

        inputManager.MainPlayerInput.GameAction.LeftStick.performed += contextMenu => {
            leftStick = contextMenu.ReadValue<Vector2>();
        };
        inputManager.MainPlayerInput.GameAction.LeftStick.canceled += contextMenu => {
            leftStick = Vector2.zero;
        };

        inputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => southButtonBehaviour(contextMenu);

        inputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => westButtonBehaviour(contextMenu);

        inputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => northButtonBehaviour(contextMenu);

        inputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => eastButtonBehaviour(contextMenu);
    }

}
