using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct JumpFeature{
    public float maxJumpTime;
    public float maxJumpHeight;
    public float timeToApex; 
    public float jumpGravity; 
    public float iniJumpVelocity;

    public JumpFeature(float maxJumpTime, float maxJumpHeight){
        this.maxJumpTime = maxJumpTime;
        this.maxJumpHeight = maxJumpHeight;
        timeToApex = maxJumpTime / 2;
        jumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        iniJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }
}

public class JumpBehaviour : MonoBehaviour{

    void OnEnable() {

    }

    void OnDisable() {
        
    }
}
