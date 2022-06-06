using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{

    public static InputManager instance;    
    List<PlayerInput> playerInputList = new List<PlayerInput>();
    public PlayerInput MainPlayerInput { get{ return playerInputList[0]; } }

    private void Awake() {
        SingletonPattern();
        AddNewPlayerInput();
    }

    void Start() {
        EnableInputAsset(MainPlayerInput);    
    }

    void SingletonPattern(){
        if(instance == null) instance = this;
        else Destroy(this);
    }
    
    void AddNewPlayerInput() => playerInputList.Add(new PlayerInput());
    void RemovePlayerInput(PlayerInput playerInput) => playerInputList.Remove(playerInput);
    
    void EnableInputAsset( PlayerInput playerInput, bool enable = true ) {
        if(enable) playerInput.Enable();
        else playerInput.Disable();
    }

    public void DisableAllInputs(){
        foreach (var inputAsset in playerInputList){
            EnableInputAsset(inputAsset, false);
        }
    }

}
