using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Dash : MonoBehaviour, IPressReleaseAction{
    InputActionManager InputActionManager { get => PlayerManager.instance.InputActionManager; }
    [SerializeField] protected AnimationManager AnimationManager { get => PlayerManager.instance.AnimationManager; }
    [SerializeField] protected Rigidbody CharacterRigidbody { get => PlayerManager.instance.CharacterRigidbody; }
    [SerializeField] GameObject forwardReference; 
    [SerializeField] protected bool canDash = true;
    [SerializeField] protected float dashSpeed = 5;
    [SerializeField] protected float dashTime;
    [SerializeField] protected int dashRecoveryTime = 1;


    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => DashAction();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext){
        
    }

    protected virtual void DashAction(){
        if(!canDash)
            return;

        canDash = false;
        DashActive(forwardReference.transform.forward.normalized, dashTime);
        CallDashAnimation();
    }

    protected virtual void CallDashAnimation(){
        if(!AnimationManager)
            return;     
        AnimationManager.PlayAnimation(Animations.DashPose);
    }

    async void DashActive(Vector3 direction, float dashTime) {
        while (dashTime > 0) {
            dashTime -= Time.fixedDeltaTime;
            CharacterRigidbody.velocity = direction * dashSpeed;
            await Task.Yield();
        }
        CharacterRigidbody.velocity = Vector3.zero;
        EndDashBehavior();
    }

    async void DashReload(int dashRecoveryTime){
        await Task.Delay(dashRecoveryTime * 1000);
        canDash = true;
    }

    protected virtual void EndDashBehavior() => DashReload(dashRecoveryTime);

    void OnEnable() {
        InputActionManager.OnRightShoulderButtonPerformed += OnButtonPressed;
        InputActionManager.OnRightShoulderButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        InputActionManager.OnRightShoulderButtonPerformed -= OnButtonPressed;
        InputActionManager.OnRightShoulderButtonCanceled -= OnButtonReleased;
    }
}
