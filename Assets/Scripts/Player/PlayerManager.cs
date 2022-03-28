using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] Rigidbody rigidbody;

    public MovementManager MovementManager { get{ return movementManager; } }
    public InputManager InputManager { get { return inputManager; } }
    public Rigidbody CharacterRigidbody { get { return rigidbody; } }
    
    private void Awake() {
        if (instance != null) instance = this;
        else Destroy(this);
    } 

}
