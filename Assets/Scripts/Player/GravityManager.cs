using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GravityType{
    onGrounded,
    onFalling,
    onJumping
}

public class GravityManager : MonoBehaviour{
    
    PlayerManager PlayerManager { get{ return PlayerManager.instance; } }

    [SerializeField] GravityType gravityType = GravityType.onGrounded;
    [SerializeField] float distToGround = 0.1f;
    [SerializeField] float groundDistanceOffset = 0;
    [SerializeField] string groundTag;
    [SerializeField] Vector3 gravityForce;

    void FixedUpdate() {
        GravityApplication();    
    }

    void GravityApplication(){
        switch(gravityType){
            case GravityType.onGrounded:
                PlayerManager.CharacterRigidbody.velocity = gravityForce;
                break;
            case GravityType.onFalling:
                break;
            case GravityType.onJumping:
                break;
        }
    }

    

    public bool IsGrounded() {
        RaycastHit hitGround;
        if (Physics.Raycast(transform.position, -transform.up, out hitGround, distToGround + 0.1f + groundDistanceOffset) && hitGround.transform.gameObject.CompareTag(groundTag))
            return true;
        else
            return false;
    }
}
