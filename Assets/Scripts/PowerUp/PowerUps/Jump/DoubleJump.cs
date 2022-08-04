using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleJump : MonoBehaviour, IPressReleaseAction{
    PlayerManager PlayerManager{ get{ return PlayerManager.instance; } }

    [SerializeField] LayerMask groundLayer;
    [SerializeField] JumpFeature firstJump;
    [SerializeField] JumpFeature secondJump;
    JumpFeature actualJump;
    bool canDoubleJump = true;

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => Jump();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => CancelJump();

    void Jump(){
        if(IsGrounded()){
            actualJump = firstJump;
            SetJumpValues(actualJump);
            canDoubleJump = true;
        }else if(canDoubleJump){
            actualJump = secondJump;
            SetJumpValues(actualJump);
            canDoubleJump = false;
        }         
    }
    
    void SetJumpValues(JumpFeature jump){
        PlayerManager.GravityManager.IsUsingSpecialGravity = true;
        PlayerManager.CharacterRigidbody.velocity = Vector3.zero;
        PlayerManager.GravityManager.GravityForce = -jump.JumpGravity;
        PlayerManager.CharacterRigidbody.AddForce(jump.IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
    }

    void CancelJump(){
        if(!IsGrounded()){
            const float GRAVITY_FALL_MULTIPLIER = 1.8f;
            PlayerManager.GravityManager.GravityForce = -actualJump.JumpGravity * GRAVITY_FALL_MULTIPLIER;
        }
    }

    bool IsGrounded(float groundDistanceOffset = 0) {
        float distToGround = transform.localScale.y;
        const float OFFSET = 0.5f;   
        if (Physics.Raycast(transform.position, -transform.up, distToGround + OFFSET + groundDistanceOffset, groundLayer))
            return true;
        else
            return false;
    }

    void OnEnable() {
        PlayerManager.InputActionManager.OnSouthSecondaryButtonPerformed += OnButtonPressed;
        PlayerManager.InputActionManager.OnSouthSecondaryButtonCanceled += OnButtonReleased;
    }

    void OnDisable() {
        PlayerManager.InputActionManager.OnSouthSecondaryButtonPerformed -= OnButtonPressed;
        PlayerManager.InputActionManager.OnSouthSecondaryButtonCanceled -= OnButtonReleased;
    }
}
