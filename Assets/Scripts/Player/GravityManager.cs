using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour{
    
    PlayerManager PlayerManager { get{ return PlayerManager.instance; } }
    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] float gravityForce;
    Vector3 gravityDirection = Vector3.down;
    bool isGrounded = false;
    [SerializeField] bool isUsingSpecialGravity = false;
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
                const float BASE_GRAVITY_FORCE = 9.8f;
                gravityForce = BASE_GRAVITY_FORCE;
                isUsingSpecialGravity = false;
            }
            else if(!isUsingSpecialGravity){
                const float FALLING_GRAVITY_FORCE = 9.8f;
                gravityForce = FALLING_GRAVITY_FORCE;
            }
    }

    void GravityApply() => PlayerManager.CharacterRigidbody.AddForce(gravityDirection * gravityForce);

}