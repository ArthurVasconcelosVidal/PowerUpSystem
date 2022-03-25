using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputManager inputManager;

    public MovementManager MovementManager { get{ return movementManager; } }
    public InputManager InputManager { get { return inputManager; } }
    
    private void Awake() {
        if (instance != null) instance = this;
        else Destroy(this);
    } 

}
