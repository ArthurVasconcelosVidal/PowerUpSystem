using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour{
    
    PlayerManager PlayerManager { get{ return PlayerManager.instance; } }

    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] string groundTag;
    [SerializeField] float gravityForce;
    Vector3 gravityDirection = Vector3.down;

    public float GravityForce { get => gravityForce; set{ gravityForce = value; } }
    public Vector3 GravityDirection { get => gravityDirection; set{ gravityDirection = value; } }

    void FixedUpdate() {
        GravityApply();
    }

    public void GravityTypeSelector(GravityType gravityType) => this.gravityType = gravityType;

    void GravityApply() => PlayerManager.CharacterRigidbody.velocity = gravityDirection * gravityForce;

}
