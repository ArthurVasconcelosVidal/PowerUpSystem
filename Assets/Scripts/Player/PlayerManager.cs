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
    [SerializeField] ColliderManager colliderManager;
    [SerializeField] GameObject interactiveObject;
    [SerializeField] WeaponManager weaponManager;

    public MovementManager MovementManager { get => movementManager; }
    public InputManager InputManager { get => inputManager; }
    public Rigidbody CharacterRigidbody { get => rigidbody; }
    public GameObject MeshObject { get => meshObject; }
    public ActionManager ActionManager { get => actionManager; }
    public GameObject InteractiveObject { get => interactiveObject; 
                                          set { if(value != null && value.GetComponent<IInteractBehaviour>() != null)  interactiveObject = value;
                                                else interactiveObject = null; 
                                              } 
                                        }
    public ColliderManager ColliderManager { get => colliderManager; }
    public WeaponManager WeaponManager { get => weaponManager; }
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

}
