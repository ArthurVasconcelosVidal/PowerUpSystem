using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour{
    InputManager inputManager;
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

    }

    void Start() {
        inputManager = InputManager.instance;
        SetUpGameAction();
        
        //inputManager.MainPlayerInput.GameAction.Disable();
        //inputManager.MainPlayerInput.UIAction.Enable();
        //var teste = inputManager.MainPlayerInput.GameAction.Get();
        //teste.Disable();
        //InputAction outAction;
        //Debug.Log($"{inputManager.MainPlayerInput.FindBinding(0, outAction)}");
        //inputManager.MainPlayerInput.Disable(); //Disable Evertything
        //Debug.Log($"GameAction = {inputManager.MainPlayerInput.GameAction.enabled}");
        //Debug.Log($"UIAction = {inputManager.MainPlayerInput.UIAction.enabled}");
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

        inputManager.MainPlayerInput.GameAction.SouthButton.performed += contextMenu => {
            southButtonBehaviour(contextMenu);
        };

        inputManager.MainPlayerInput.GameAction.WestButton.performed += contextMenu => {
            westButtonBehaviour(contextMenu.ReadValue<float>());
        };

        inputManager.MainPlayerInput.GameAction.NorthButton.performed += contextMenu => {
            northButtonBehaviour(contextMenu.ReadValue<float>());
        };

        inputManager.MainPlayerInput.GameAction.EastButton.performed += contextMenu => {
            eastButtonBehaviour(contextMenu.ReadValue<float>());
        };
    }

}
