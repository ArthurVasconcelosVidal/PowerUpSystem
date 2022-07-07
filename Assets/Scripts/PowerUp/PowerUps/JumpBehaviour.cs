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
    InputActionManager PlayerInputManager { get{ return PlayerManager.instance.InputActionManager; } }

    JumpFeature[] jumpList = new JumpFeature[3];
    void Start() {
        
    }

    void Jump(object sender, InputAction.CallbackContext buttonContext){
        Debug.Log("jump");
    }

    void OnEnable() {
        //Debug.Log($"maxJumpTime: {teste.MaxJumpTime} \n maxJumpHeight: {teste.MaxJumpHeight} \n timeToApex: {teste.TimeToApex} \n jumpGravity: {teste.JumpGravity} \n iniJumpVelocity: {teste.IniJumpVelocity}");
        PlayerInputManager.OnSouthButtonPerformed += Jump;
    }

    void OnDisable() {
        PlayerInputManager.OnSouthButtonPerformed -= Jump;
    }
}
