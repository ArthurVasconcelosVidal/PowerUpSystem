using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;

    [SerializeField] MovementManager movementManager;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] GameObject spawnProjectilePoint;
    [SerializeField] GravityManager gravityManager;
    [SerializeField] List<IPressReleaseAction> poewers = new List<IPressReleaseAction>();

    public MovementManager MovementManager { get => movementManager; }
    public InputActionManager InputActionManager { get => inputActionManager; }
    public Rigidbody CharacterRigidbody { get => rigidbody; }
    public GameObject MeshObject { get => meshObject; }
    public GameObject SpawnProjectilePoint { get => spawnProjectilePoint; }
    public GravityManager GravityManager { get => gravityManager;}
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

    public void EnableMovement(bool enable) => movementManager.enabled = enable;

    public void EnablePowers(bool enable){

    }

    public void EnableGravity(bool enable) => gravityManager.enabled = enable;

}
