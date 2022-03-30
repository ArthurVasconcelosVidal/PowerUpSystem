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

    public MovementManager MovementManager { get => movementManager; }
    public InputManager InputManager { get => inputManager; }
    public Rigidbody CharacterRigidbody { get => rigidbody; }
    public GameObject MeshObject { get => meshObject; }
    public ActionManager ActionManager { get => actionManager; }
    public GameObject InteractiveObject { get => InteractiveObject; 
                                          set { if(value.GetComponent<IInteractBehaviour>() != null) InteractiveObject = value; } }
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

}
