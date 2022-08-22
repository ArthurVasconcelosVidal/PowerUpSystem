using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleJump : MonoBehaviour, IPressReleaseAction{
    [SerializeField] Animator animator = null;
    [SerializeField] GravityManager gravityManager;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] JumpFeature firstJump;
    [SerializeField] JumpFeature secondJump;
    JumpFeature actualJump;
    bool canDoubleJump = true;
    /*
        TODO: 
            - Refactor to make the script more independent
            - Remove PLayer Manager dependency
            - Add a variable to control the cancel fall Gravity constant
    */
    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => Jump();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => CancelJump();

    void Jump(){
        if(IsGrounded()){
            actualJump = firstJump;
            SetJumpValues(actualJump);
            CallJumpAnimation();
            canDoubleJump = true;
        }else if(canDoubleJump){
            actualJump = secondJump;
            SetJumpValues(actualJump);
            CallJumpAnimation();
            canDoubleJump = false;
        }         
    }
    
    void CallJumpAnimation(){
        if(!animator)
            return;     
        animator.applyRootMotion = false;
        animator.SetTrigger("Jump");
    }

    void SetJumpValues(JumpFeature jump){
        gravityManager.IsUsingSpecialGravity = true;
        rigidbody.velocity = Vector3.zero;
        gravityManager.GravityForce = -jump.JumpGravity;
        rigidbody.AddForce(jump.IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
    }

    void CancelJump(){
        if(!IsGrounded()){
            const float GRAVITY_FALL_MULTIPLIER = 1.7f;
            gravityManager.GravityForce = -actualJump.JumpGravity * GRAVITY_FALL_MULTIPLIER;
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
        inputActionManager.OnSouthSecondaryButtonPerformed += OnButtonPressed;
        inputActionManager.OnSouthSecondaryButtonCanceled += OnButtonReleased;
    }

    void OnDisable() {
        inputActionManager.OnSouthSecondaryButtonPerformed -= OnButtonPressed;
        inputActionManager.OnSouthSecondaryButtonCanceled -= OnButtonReleased;
    }
}
