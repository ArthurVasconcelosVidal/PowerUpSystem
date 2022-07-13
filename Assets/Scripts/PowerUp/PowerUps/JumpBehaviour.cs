using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

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
    [SerializeField] int jumpPhase = 0;
    void Awake(){
        jumpList[0] = new JumpFeature(0.8f, 5); 
        jumpList[1] = new JumpFeature(1f, 7); 
        jumpList[2] = new JumpFeature(1.1f, 10); 
    }

    void Jump(object sender, InputAction.CallbackContext buttonContext){
        if(PlayerManager.GravityManager.IsGrounded){
            PlayerManager.GravityManager.IsUsingSpecialGravity = true;
            PlayerManager.CharacterRigidbody.AddForce(jumpList[jumpPhase].IniJumpVelocity * Vector3.up, ForceMode.VelocityChange);
            PlayerManager.GravityManager.GravityForce = -jumpList[jumpPhase].JumpGravity;
            NextJump();
        }         
    }
    
    async void CancelJump(object sender, InputAction.CallbackContext buttonContext){
        await Task.Delay(100);
        if(!PlayerManager.GravityManager.IsGrounded){
            const float GRAVITY_FALL_MULTIPLIER = 1.8f;
            PlayerManager.GravityManager.GravityForce = -jumpList[0].JumpGravity * GRAVITY_FALL_MULTIPLIER;
        }
    }

    void NextJump(){
        const int TOTAL_JUMPS = 3;
        if(jumpPhase + 1 < TOTAL_JUMPS)
            jumpPhase ++;
        else
            jumpPhase = 0;
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
