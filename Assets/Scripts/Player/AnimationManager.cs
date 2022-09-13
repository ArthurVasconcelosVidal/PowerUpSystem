using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;

public class AnimationManager : MonoBehaviour{

    [SerializeField] Animator playerAnimator;
    [SerializeField] int actualAnimPriority = 0;

    public Animator Animator {get => playerAnimator;}

    public void EnableRootMotion(bool enable =  true) => playerAnimator.applyRootMotion = enable;

    public void CrossFadeFixedTimePlay(Animations anim, float fixedTransitionDuration){
        VerifyZeroPriorityState();
        int nextAnimPriority = AnimationsDictonary.animations[anim];
        if(nextAnimPriority > actualAnimPriority){
            playerAnimator.CrossFadeInFixedTime(anim.ToString(), fixedTransitionDuration);
            actualAnimPriority = nextAnimPriority;
        } 
    }

    public void PlayAnimation(Animations anim, int animLayer = 0){
        VerifyZeroPriorityState();
        int nextAnimPriority = AnimationsDictonary.animations[anim];
        if(nextAnimPriority > actualAnimPriority){
            playerAnimator.Play(anim.ToString(), animLayer);
            actualAnimPriority = nextAnimPriority;
        }
    }

    void VerifyZeroPriorityState(){
        if(ActualAnimName() == Animations.IdleToRunTree.ToString() || ActualAnimName() == Animations.FallingIdle.ToString())
            actualAnimPriority = 0;
    }

    string ActualAnimName() => playerAnimator.GetCurrentAnimatorClipInfo(0)[0].ToString();
}
