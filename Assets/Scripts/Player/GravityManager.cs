using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour{

    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] Rigidbody characterRigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] float gravityForce;
    [SerializeField] bool isUsingSpecialGravity = false;
    [SerializeField] LayerMask groundLayer;
    Vector3 gravityDirection = Vector3.down;
    bool isGrounded = false;
    float fallingGravityForce = 9.8f;
    float baseGravityForce = 15f;

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
                gravityForce = baseGravityForce;
                isUsingSpecialGravity = false;
                GravityDirection = Vector3.down;
                characterRigidbody.velocity = Vector3.zero;
                RotateAlignToGround();
            }
            else if(!isUsingSpecialGravity){
                gravityForce = fallingGravityForce;
                GravityDirection = Vector3.down;
            }
    }

    void GravityApply() => characterRigidbody.AddForce(gravityDirection * gravityForce);
    
    void RotateAlignToGround(){
        float distToGround = transform.localScale.y;
        RaycastHit hit;
        const float OFFSET = 0.1f;
        if(Physics.Raycast(transform.position, -transform.up, out hit, distToGround + OFFSET, groundLayer)){
            var newRotation = Quaternion.FromToRotation(meshObject.transform.up, hit.normal) * meshObject.transform.rotation;
            meshObject.transform.rotation = newRotation;
        }
    }

    public void ResetGravity(){
        GravityDirection = Vector3.down;
        GravityForce = baseGravityForce;
        isUsingSpecialGravity = false;
    }
}