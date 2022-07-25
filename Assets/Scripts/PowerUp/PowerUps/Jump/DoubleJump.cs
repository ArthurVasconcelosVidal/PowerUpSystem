using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleJump : MonoBehaviour{
    PlayerManager PlayerManager{ get{ return PlayerManager.instance; } }
    [SerializeField] LayerMask groundLayer;
    [SerializeField] JumpFeature firstJump;
    [SerializeField] JumpFeature secondJump;
    JumpFeature actualJump;

    bool canDoubleJump;

    void Jump(object sender, InputAction.CallbackContext buttonContext){
        if(IsGrounded()){
            canDoubleJump = true;
            actualJump = firstJump;
            Test(actualJump);
        }else if(canDoubleJump){
            actualJump = secondJump;
            Test(actualJump);
            canDoubleJump = false;
        }         
    }
    
    void Test(JumpFeature jump){
        PlayerManager.GravityManager.IsUsingSpecialGravity = true;
        PlayerManager.GravityManager.GravityForce = -jump.JumpGravity;
        PlayerManager.CharacterRigidbody.AddForce(jump.IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
    }

    void CancelJump(object sender, InputAction.CallbackContext buttonContext){
        if(!IsGrounded()){
            const float GRAVITY_FALL_MULTIPLIER = 1.8f;
            PlayerManager.GravityManager.GravityForce = -actualJump.JumpGravity * GRAVITY_FALL_MULTIPLIER;
        }
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
