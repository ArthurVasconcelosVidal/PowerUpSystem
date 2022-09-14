using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;

public class AnimationManager : MonoBehaviour{

    [SerializeField] Animator playerAnimator;
    [SerializeField] int actualAnimPriority = 0;
    //BlendTree teste;
    /*
        TODO:
            - Fix jump and dash animations
            - the actual anim priority value doesnt change from 1
    */
    public Animator Animator {get => playerAnimator;}

    public void EnableRootMotion(bool enable =  true) => playerAnimator.applyRootMotion = enable;

    public void PlayAnimation(Animations anim, float fixedTransitionDuration = 0, int animLayer = 0){
        VerifyZeroPriorityState();
        int nextAnimPriority = AnimationsDictonary.animations[anim];
        if(nextAnimPriority >= actualAnimPriority){
            if(fixedTransitionDuration > 0) playerAnimator.CrossFadeInFixedTime(anim.ToString(), fixedTransitionDuration, animLayer);
            else playerAnimator.Play(anim.ToString(), animLayer);
            actualAnimPriority = nextAnimPriority;
        }
    }

    void VerifyZeroPriorityState(){
        string actualAnim = ActualAnimName();
        if(actualAnim == Animations.BreathingIdle.ToString() 
        || actualAnim == Animations.SilentWalking.ToString()
        || actualAnim == Animations.Walking.ToString()
        || actualAnim == Animations.Running.ToString()
        || actualAnim == Animations.PanicRunning.ToString()
        || actualAnim == Animations.FallingIdle.ToString())
            actualAnimPriority = 0;
    }

    string ActualAnimName() => playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
}
