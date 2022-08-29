using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class SpaceImpulse : MonoBehaviour, IPressReleaseAction{
    [SerializeField] SpaceImpulse targetSpaceImpulse;
    [SerializeField] bool usingSpaceImpulse;
    [SerializeField] string playerTag;
    [SerializeField] float velocity;
    [SerializeField] float gravityForce;
    [SerializeField] float timeToEnd;
    GravityManager playerGravity;

    GameObject player;
    /*
        TODO:
            - Neutralize gravity force and apply a force to the center (Feito)
            - Disable gravity point after a certain quantity of time or when the player press a button to cancel the space impulse (Feito)
            - Disable any movement or powerUp (Make easy to disable specific inputs (like disable a button)) (Feito)

            - Make the movement to the next object (can use spherical interpolation to move between two points)
            - Make the posibility of unlimited stop points in the movement (can make a trail if space impulse)
            - make the movement Smooth
            - get some animation to no gravity space
    */
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            usingSpaceImpulse = true;
            player = other.gameObject;
            playerGravity = player.GetComponent<GravityManager>();
            ChangeGravity();
            EnablePlayerComponents(false);
            ButtonBehaviour(true);
            TimeToQuit();
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag(playerTag) && usingSpaceImpulse){
            playerGravity.GravityDirection = (transform.position - other.transform.position).normalized;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            EnablePlayerComponents(true);
            ButtonBehaviour(false);
            playerGravity.ResetGravity();
            usingSpaceImpulse = false;    
        }
    }

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => QuitImpulseSpace();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => LaunchPlayer();

    void EnablePlayerComponents(bool enable = true){
        var playerInput = player.GetComponent<InputActionManager>();
        playerInput.EnableAllControlInputs(enable);
        playerInput.southButtonActive = true;
        playerInput.eastButtonActive = true;
    }

    void ChangeGravity(){
        var playerRb = player.GetComponent<Rigidbody>();
        playerRb.velocity = Vector3.zero;
        playerGravity.IsUsingSpecialGravity = true;
        playerGravity.GravityForce = gravityForce;
    }

    async void TimeToQuit(){
        await Task.Delay((int)timeToEnd*1000);
        QuitImpulseSpace();
    }

    void QuitImpulseSpace(){
        if(usingSpaceImpulse){
            playerGravity.ResetGravity();
            usingSpaceImpulse = false;
        }
    }

    void LaunchPlayer(){
        //var playerGravity = player.GetComponent<> 
    }

    void ButtonBehaviour(bool enable){
        var playerInput = player.GetComponent<InputActionManager>();
        if(enable){
            playerInput.OnEastPrimaryButtonPerformed += OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed += OnButtonReleased;
        }else{
            playerInput.OnEastPrimaryButtonPerformed -= OnButtonPressed;
            playerInput.OnSouthPrimaryButtonPerformed -= OnButtonReleased;
        }
    }
}
