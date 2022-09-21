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

    void Spin(){
        if(canSpin){
            canSpin = false;
            SpinBehaviour();
            SpinReload(spinRecoveryTime);
        }
    }

    async void SpinBehaviour(){
        attackManager.EnableAttackTrigger(true);
        SpinAnimation(true);
        await Task.Delay((int)(spinAttackTime*1000));
        attackManager.EnableAttackTrigger(false);
        SpinAnimation(false);
    }

    async void SpinReload(float recoveryTime){
        await Task.Delay((int)(recoveryTime*1000));
        canSpin = true;
    }

    void SpinAnimation(bool status){
        animationManager.Animator.SetBool(Animations.SpinPose.ToString(), status);
        if(status) animationManager.PlayAnimation(Animations.SpinPose);
    }

    public override void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => Spin();
}
