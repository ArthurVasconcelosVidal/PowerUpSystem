using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour{
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

        SetUpGameAction();
        
        playerInput.GameAction.Disable();
        playerInput.UIAction.Enable();
        var teste = playerInput.GameAction.Get();
        teste.Disable();
        //InputAction outAction;
        //Debug.Log($"{playerInput.FindBinding(0, outAction)}");
        //playerInput.Disable(); //Disable Evertything
        Debug.Log($"GameAction = {playerInput.GameAction.enabled}");
        Debug.Log($"UIAction = {playerInput.UIAction.enabled}");
    }

    void SetUpGameAction(){
        playerInput.GameAction.RightStick.performed += contextMenu => {
            rightStick = contextMenu.ReadValue<Vector2>();
        };
        playerInput.GameAction.RightStick.canceled += contextMenu => {
            rightStick = Vector2.zero;
        };

        playerInput.GameAction.LeftStick.performed += contextMenu => {
            leftStick = contextMenu.ReadValue<Vector2>();
        };
        playerInput.GameAction.LeftStick.canceled += contextMenu => {
            leftStick = Vector2.zero;
        };

        playerInput.GameAction.SouthButton.performed += contextMenu => {
            southButtonBehaviour(contextMenu);
        };

        playerInput.GameAction.WestButton.performed += contextMenu => {
            westButtonBehaviour(contextMenu.ReadValue<float>());
        };

        playerInput.GameAction.NorthButton.performed += contextMenu => {
            northButtonBehaviour(contextMenu.ReadValue<float>());
        };

        playerInput.GameAction.EastButton.performed += contextMenu => {
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
