using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    PlayerInput playerInput;

    [SerializeField] Vector2 rightStick;
    [SerializeField] Vector2 leftStick;

    public Vector2 RightStickValue { get { return rightStick; } }
    public Vector2 LeftStickValue { get { return leftStick; } }
    
    #region Button Delegates
    public delegate void SouthButtonBehaviour(float buttonValue);
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

        playerInput.PlayerActions.RightStick.performed += ContextMenu => {
            rightStick = ContextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.RightStick.canceled += ContextMenu => {
            rightStick = Vector2.zero;
        };

        playerInput.PlayerActions.LeftStick.performed += ContextMenu => {
            leftStick = ContextMenu.ReadValue<Vector2>();
        };
        playerInput.PlayerActions.LeftStick.canceled += ContextMenu => {
            leftStick = Vector2.zero;
        };

        playerInput.PlayerActions.SouthButton.performed += ContextMenu => {
            southButtonBehaviour(ContextMenu.ReadValue<float>());
        };

        playerInput.PlayerActions.WestButton.performed += ContextMenu => {
            westButtonBehaviour(ContextMenu.ReadValue<float>());
        };

        playerInput.PlayerActions.NorthButton.performed += ContextMenu => {
            northButtonBehaviour(ContextMenu.ReadValue<float>());
        };

        playerInput.PlayerActions.EastButton.performed += ContextMenu => {
            eastButtonBehaviour(ContextMenu.ReadValue<float>());
        };
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

}
