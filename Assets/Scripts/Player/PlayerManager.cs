using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] GameObject spawnProjectilePoint;
    [SerializeField] GravityManager gravityManager;

    public MovementManager MovementManager { get => movementManager; }
    public InputActionManager InputActionManager { get => inputActionManager; }
    public Rigidbody CharacterRigidbody { get => rigidbody; }
    public GameObject MeshObject { get => meshObject; }
    public WeaponManager WeaponManager { get => weaponManager; }
    public GameObject SpawnProjectilePoint { get => spawnProjectilePoint; }
    public GravityManager GravityManager { get => gravityManager;}
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

}
