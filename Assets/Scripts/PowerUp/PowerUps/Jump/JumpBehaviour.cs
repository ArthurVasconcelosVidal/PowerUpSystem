using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System.Threading;

public class JumpBehaviour : MonoBehaviour{

    PlayerManager PlayerManager{ get{ return PlayerManager.instance; } }
    JumpFeature[] jumpList = new JumpFeature[3];
    [SerializeField] LayerMask groundLayer;
    int jumpPhase = -1;
    float lastTimeClicked = 0;

    void Awake(){
        jumpList[0] = new JumpFeature(0.5f, 4); 
        jumpList[1] = new JumpFeature(0.8f, 7); 
        jumpList[2] = new JumpFeature(0.9f, 8.5f); 
    }

    void Jump(object sender, InputAction.CallbackContext buttonContext){
        if(IsGrounded()){
            NextJump();
            PlayerManager.GravityManager.IsUsingSpecialGravity = true;
            PlayerManager.CharacterRigidbody.AddForce(jumpList[jumpPhase].IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
            PlayerManager.GravityManager.GravityForce = -jumpList[jumpPhase].JumpGravity;
        }         
    }
    
    async void CancelJump(object sender, InputAction.CallbackContext buttonContext){
        await Task.Delay(100);
        if(!IsGrounded()){
            const float GRAVITY_FALL_MULTIPLIER = 1.8f;
            PlayerManager.GravityManager.GravityForce = -jumpList[jumpPhase].JumpGravity * GRAVITY_FALL_MULTIPLIER;
        }
    }

    void NextJump(){
        const int TOTAL_JUMPS = 3;
        const float MAX_TIME = 2f;

        if(jumpPhase + 1 < TOTAL_JUMPS &&  Time.time - lastTimeClicked <= MAX_TIME)
            jumpPhase ++;
        else
            jumpPhase = 0;
            
        lastTimeClicked = Time.time;
    }
 
    bool IsGrounded(float groundDistanceOffset = 0) {
        float distToGround = transform.localScale.y; 
        if (Physics.Raycast(transform.position, -transform.up, distToGround + 0.05f + groundDistanceOffset, groundLayer))
            return true;
        else
            return false;
    }

    void OnEnable() {
        PlayerManager.InputActionManager.OnSouthButtonPerformed += Jump;
        PlayerManager.InputActionManager.OnSouthButtonCanceled += CancelJump;
    }

    void OnDisable() {
        PlayerManager.InputActionManager.OnSouthButtonPerformed -= Jump;
        PlayerManager.InputActionManager.OnSouthButtonCanceled -= CancelJump;
    }
}
