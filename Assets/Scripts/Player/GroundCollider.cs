using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour{
    GravityManager GravityManager { get => PlayerManager.instance.GravityManager; }
    [SerializeField] Animator playerAnimator;

    void OnTriggerEnter(Collider other) {
        GravityManager.IsGrounded = true;
        if(playerAnimator) playerAnimator.SetBool("OnGround", true);
    }

    void OnTriggerExit(Collider other) {
        GravityManager.IsGrounded = false;
        if(playerAnimator) playerAnimator.SetBool("OnGround", false);
    }
}
