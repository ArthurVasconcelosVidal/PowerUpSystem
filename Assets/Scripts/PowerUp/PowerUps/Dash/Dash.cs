using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Dash : MonoBehaviour, IPressReleaseAction{
    [SerializeField] InputActionManager playerInput;
    [SerializeField] protected AnimationManager animationManager;
    [SerializeField] protected Rigidbody playerRigidBody;
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
        if(!animationManager)
            return;     
        animationManager.PlayAnimation(Animations.DashPose);
    }

    async void DashActive(Vector3 direction, float dashTime) {
        while (dashTime > 0) {
            dashTime -= Time.fixedDeltaTime;
            playerRigidBody.velocity = direction * dashSpeed;
            await Task.Yield();
        }
        playerRigidBody.velocity = Vector3.zero;
        EndDashBehavior();
    }

    async void DashReload(int dashRecoveryTime){
        await Task.Delay(dashRecoveryTime * 1000);
        canDash = true;
    }

    protected virtual void EndDashBehavior() => DashReload(dashRecoveryTime);

    void OnEnable() {
        playerInput.OnRightShoulderButtonPerformed += OnButtonPressed;
        playerInput.OnRightShoulderButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnRightShoulderButtonPerformed -= OnButtonPressed;
        playerInput.OnRightShoulderButtonCanceled -= OnButtonReleased;
    }
}
