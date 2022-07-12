using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour{
    GravityManager GravityManager { get => PlayerManager.instance.GravityManager; }

    void OnTriggerEnter(Collider other) {
        GravityManager.IsGrounded = true;
    }

    void OnTriggerExit(Collider other) {
        GravityManager.IsGrounded = false;
    }
}
