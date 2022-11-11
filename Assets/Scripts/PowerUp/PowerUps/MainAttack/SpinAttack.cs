using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SpinAttack : MainAttack{
    float spinTime;
    [SerializeField] float spinRecoveryTime;
    [SerializeField] float spinAttackTime;
    [SerializeField] bool canSpin = true;
    [SerializeField] AttackInfo attackInfo;

    void Spin(){
        if(canSpin){
            canSpin = false;
            SpinBehaviour();
            SpinReload(spinRecoveryTime);
        }
    }

    async void SpinBehaviour(){
        AttackManager.EnableAttackTrigger(attackInfo);
        SpinAnimation(true);
        await Task.Delay((int)(spinAttackTime*1000));
        AttackManager.DisableAttackTrigger();
        SpinAnimation(false);
    }

    async void SpinReload(float recoveryTime){
        await Task.Delay((int)(recoveryTime*1000));
        canSpin = true;
    }

    void SpinAnimation(bool status){
        AnimationManager.Animator.SetBool(Animations.SpinPose.ToString(), status);
        if(status) AnimationManager.PlayAnimation(Animations.SpinPose);
    }

    public override void OnButtonPressed(InputAction.CallbackContext buttonContext) => Spin();
}
