using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour{

    Rigidbody PlayerRb { get => PlayerManager.instance.CharacterRigidbody; }
    GravityManager PlayerGravityManager { get => PlayerManager.instance.GravityManager; }
    AnimationManager PlayerAnimationManager { get => PlayerManager.instance.AnimationManager; }
    [SerializeField] string playerTag;
    [SerializeField] JumpFeature jumpFeature;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(playerTag)){
            TrampolineJump(other.gameObject);
            CallJumpAnimation(other.gameObject);
            ResetDoubleJump(other.gameObject);
        }
    }

    void TrampolineJump(GameObject target){
        PlayerGravityManager.IsUsingSpecialGravity = true;
        PlayerRb.velocity = Vector3.zero;
        PlayerGravityManager.GravityForce = -jumpFeature.JumpGravity;
        PlayerRb.AddForce(jumpFeature.IniJumpVelocity * transform.up, ForceMode.VelocityChange);
    }
    
    void CallJumpAnimation(GameObject target){
        if(PlayerAnimationManager){
            PlayerAnimationManager.PlayAnimation(Animations.TrampolineJump, 0);
        }
    }

    void ResetDoubleJump(GameObject target){
        DoubleJump playerJumpBehavior = target.GetComponentInChildren<DoubleJump>();
        if(playerJumpBehavior){
            playerJumpBehavior.CanDoubleJump = true;
        }
    }
}
