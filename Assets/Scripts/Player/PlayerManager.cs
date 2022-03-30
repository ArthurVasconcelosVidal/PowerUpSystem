using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] ActionManager actionManager;

    public MovementManager MovementManager { get{ return movementManager; } }
    public InputManager InputManager { get { return inputManager; } }
    public Rigidbody CharacterRigidbody { get { return rigidbody; } }
    public GameObject MeshObject { get { return meshObject; } }
    public ActionManager ActionManager { get { return actionManager;} }
    
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

}
