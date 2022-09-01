using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour{

    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] Rigidbody characterRigidbody;
    [SerializeField] float gravityForce;
    Vector3 gravityDirection = Vector3.down;
    bool isGrounded = false;
    [SerializeField] bool isUsingSpecialGravity = false;
    const float FALLING_GRAVITY_FORCE = 9.8f;
    const float BASE_GRAVITY_FORCE = 9.8f;

    public bool IsGrounded  { get => isGrounded;
                                set{
                                    isGrounded = value;
                                    GravityBehaviour();
                                    }
                            }
    public bool IsUsingSpecialGravity { get => isUsingSpecialGravity; set => isUsingSpecialGravity = value; }
    public float GravityForce { get => gravityForce; set{ gravityForce = value; } }
    public Vector3 GravityDirection { get => gravityDirection; set{ gravityDirection = value; } }

    void Start() {
        GravityBehaviour();    
    }

    void FixedUpdate() {
        GravityApply();
    }

    public void GravityTypeSelector(GravityType gravityType) => this.gravityType = gravityType;

    void GravityBehaviour(){
            if(IsGrounded){
                gravityForce = BASE_GRAVITY_FORCE;
                isUsingSpecialGravity = false;
                GravityDirection = Vector3.down;
                characterRigidbody.velocity = Vector3.zero;
            }
            else if(!isUsingSpecialGravity){
                gravityForce = FALLING_GRAVITY_FORCE;
                GravityDirection = Vector3.down;
            }
    }

    void GravityApply() => characterRigidbody.AddForce(gravityDirection * gravityForce);

    public void ResetGravity(){
        GravityDirection = Vector3.down;
        GravityForce = BASE_GRAVITY_FORCE;
        isUsingSpecialGravity = false;
    }
}