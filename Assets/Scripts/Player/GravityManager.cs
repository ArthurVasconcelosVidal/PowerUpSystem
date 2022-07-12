using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour{
    
    PlayerManager PlayerManager { get{ return PlayerManager.instance; } }

    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] string groundTag;
    [SerializeField] Vector3 gravityForce;
    public Vector3 GravityForce { get => gravityForce; set{ gravityForce = value; } }

    void FixedUpdate() {
        GravityApply();
    }

    public void GravityTypeSelector(GravityType gravityType) => this.gravityType = gravityType;

    void GravityApply() => PlayerManager.CharacterRigidbody.velocity = GravityForce;

    public bool IsGrounded(float distToGround = 0.1f, float groundDistanceOffset = 0) {
        RaycastHit hitGround;
        if (Physics.Raycast(transform.position, -transform.up, out hitGround, distToGround + 0.1f + groundDistanceOffset) && hitGround.transform.gameObject.CompareTag(groundTag))
            return true;
        else
            return false;
    }

}
