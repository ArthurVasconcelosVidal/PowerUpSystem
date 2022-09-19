using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SpinAttack : MonoBehaviour, IPressReleaseAction{
    float spinTime;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] InputActionManager playerInput;
    [SerializeField] GameObject attackTrigger;
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
        attackTrigger.SetActive(true);
        SpinAnimation(true);
        await Task.Delay((int)(spinAttackTime*1000));
        attackTrigger.SetActive(false);
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

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => Spin();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext){}

    void OnEnable() {
        playerInput.OnWestButtonPerformed += OnButtonPressed;
        playerInput.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnWestButtonPerformed -= OnButtonPressed;
        playerInput.OnWestButtonCanceled -= OnButtonReleased;
    }

}
