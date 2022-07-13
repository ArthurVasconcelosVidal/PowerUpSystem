using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct JumpFeature{
    public float MaxJumpTime { get; }
    public float MaxJumpHeight { get; }
    public float TimeToApex { get; } 
    public float JumpGravity { get; } 
    public float IniJumpVelocity { get; }

    public JumpFeature(float maxJumpTime, float maxJumpHeight){
        MaxJumpTime = maxJumpTime;
        MaxJumpHeight = maxJumpHeight;
        TimeToApex = maxJumpTime / 2;
        JumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(TimeToApex, 2);
        IniJumpVelocity = (2 * maxJumpHeight) / TimeToApex;
    }
}

public class JumpBehaviour : MonoBehaviour{

    PlayerManager PlayerManager{ get{ return PlayerManager.instance; } }
    JumpFeature[] jumpList = new JumpFeature[3];
    bool inJump = false;
    const float GRAVITY_FALL_MULTIPLIER = 1.8f;

    void Awake(){
        jumpList[0] = new JumpFeature(0.5f, 5); 
        jumpList[1] = new JumpFeature(0.7f, 7); 
        jumpList[2] = new JumpFeature(0.8f, 10); 
    }

    void Start() {
        
    }

    void Jump(object sender, InputAction.CallbackContext buttonContext){
        Debug.Log("jump");
        if(PlayerManager.GravityManager.IsGrounded){
            PlayerManager.GravityManager.IsUsingSpecialGravity = true;
            Debug.Log(jumpList[0].IniJumpVelocity);
            PlayerManager.CharacterRigidbody.AddForce(jumpList[0].IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
            PlayerManager.GravityManager.GravityForce = -jumpList[0].JumpGravity;
            inJump = true;
        }         
    }

    void CancelJump(object sender, InputAction.CallbackContext buttonContext){
        //Behaviour
    }

    void OnEnable() {
        PlayerManager.InputActionManager.OnSouthButtonPerformed += Jump;
        PlayerManager.InputActionManager.OnSouthButtonCanceled += CancelJump;
    }

    void OnDisable() {
        PlayerManager.InputActionManager.OnSouthButtonPerformed -= Jump;
        PlayerManager.InputActionManager.OnSouthButtonCanceled -= CancelJump;
    }
}
