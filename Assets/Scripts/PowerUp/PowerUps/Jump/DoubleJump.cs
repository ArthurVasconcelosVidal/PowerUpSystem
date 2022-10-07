using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleJump : MonoBehaviour, IPressReleaseAction{
    AnimationManager AnimationManager { get => PlayerManager.instance.AnimationManager; }
    GravityManager GravityManager { get => PlayerManager.instance.GravityManager; }
    InputActionManager InputActionManager { get => PlayerManager.instance.InputActionManager; }
    Rigidbody CharacterRigidbody { get => PlayerManager.instance.CharacterRigidbody; }
    [SerializeField] LayerMask groundLayer;
    [SerializeField] JumpFeature firstJump;
    [SerializeField] JumpFeature secondJump;
    [SerializeField] [Range(1,2)] float fallMultiplier = 1.7f;
    JumpFeature actualJump;
    bool canDoubleJump = true;
    public bool CanDoubleJump {get => canDoubleJump; set => canDoubleJump = value;}
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
        if(!AnimationManager)
            return;
        if(IsGrounded()) AnimationManager.PlayAnimation(Animations.FirstJumping, 0.1f);
        else if(canDoubleJump) AnimationManager.PlayAnimation(Animations.DoubleJumpFlip, 0);
    }

    void SetJumpValues(JumpFeature jump){
        GravityManager.IsUsingSpecialGravity = true;
        CharacterRigidbody.velocity = Vector3.zero;
        GravityManager.GravityForce = -jump.JumpGravity;
        CharacterRigidbody.AddForce(jump.IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
    }

    void CancelJump(){
        if(!IsGrounded())
            GravityManager.GravityForce = -actualJump.JumpGravity * fallMultiplier;
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
        InputActionManager.OnSouthSecondaryButtonPerformed += OnButtonPressed;
        InputActionManager.OnSouthSecondaryButtonCanceled += OnButtonReleased;
    }

    void OnDisable() {
        InputActionManager.OnSouthSecondaryButtonPerformed -= OnButtonPressed;
        InputActionManager.OnSouthSecondaryButtonCanceled -= OnButtonReleased;
    }
}
