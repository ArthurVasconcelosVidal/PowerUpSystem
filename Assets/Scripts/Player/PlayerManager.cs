using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] ActionManager actionManager;
    [SerializeField] ColliderManager colliderManager;
    [SerializeField] GameObject interactiveObject;
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] GameObject spawnProjectilePoint;

    public MovementManager MovementManager { get => movementManager; }
    public InputActionManager InputActionManager { get => inputActionManager; }
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
    public GameObject SpawnProjectilePoint { get => spawnProjectilePoint; }
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

}
