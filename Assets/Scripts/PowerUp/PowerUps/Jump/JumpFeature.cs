using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
