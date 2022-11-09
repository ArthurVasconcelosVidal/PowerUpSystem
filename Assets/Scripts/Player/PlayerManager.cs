using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager instance;


    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] GravityManager gravityManager;
    [SerializeField] AttackManager attackManager;
    [SerializeField] InterestManager interestManager;
    [SerializeField] List<IPressReleaseAction> poewers = new List<IPressReleaseAction>();

    public InputActionManager InputActionManager { get => inputActionManager; }
    public Rigidbody CharacterRigidbody { get => rigidbody; }
    public GravityManager GravityManager { get => gravityManager;}
    public GameObject MeshObject { get => meshObject; }
    public AnimationManager AnimationManager { get => animationManager; }
    public AttackManager AttackManager { get => attackManager; }
    public InterestManager InterestManager { get => interestManager; }
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    } 

    public void EnablePowers(bool enable){

    }

    public void EnableGravity(bool enable) => gravityManager.enabled = enable;

}
