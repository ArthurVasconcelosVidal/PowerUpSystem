using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour{
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
        Rigidbody rigidbody = target.GetComponent<Rigidbody>();
        GravityManager gravityManager = target.GetComponent<GravityManager>();
        gravityManager.IsUsingSpecialGravity = true;
        rigidbody.velocity = Vector3.zero;
        gravityManager.GravityForce = -jumpFeature.JumpGravity;
        rigidbody.AddForce(jumpFeature.IniJumpVelocity * transform.up, ForceMode.VelocityChange);
    }
    
    void CallJumpAnimation(GameObject target){
        AnimationManager animationManager;
        if(target.TryGetComponent<AnimationManager>(out animationManager)){
            animationManager.PlayAnimation(Animations.TrampolineJump, 0);
        }
    }

    void ResetDoubleJump(GameObject target){
        DoubleJump playerJumpBehaviour;
        if(target.TryGetComponent<DoubleJump>(out playerJumpBehaviour)){
            playerJumpBehaviour.CanDoubleJump = true;
        }
    }
}
