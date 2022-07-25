using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/JumpFeature", order = 1)]
public class JumpFeature: ScriptableObject{
    [SerializeField] float maxJumpTime = 0;
    [SerializeField] float maxJumpHeight = 0;
    public float MaxJumpTime { get => maxJumpTime; set => maxJumpTime = value; }
    public float MaxJumpHeight { get => maxJumpHeight; set => maxJumpHeight = value; }
    public float TimeToApex { get; private set;} 
    public float JumpGravity { get; private set;} 
    public float IniJumpVelocity { get; private set;}

    void OnValidate() {
        Initialize();
    }

    void Initialize(){
        MaxJumpTime = maxJumpTime;
        MaxJumpHeight = maxJumpHeight;
        TimeToApex = maxJumpTime / 2;
        JumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(TimeToApex, 2);
        IniJumpVelocity = (2 * maxJumpHeight) / TimeToApex;
    }


}
