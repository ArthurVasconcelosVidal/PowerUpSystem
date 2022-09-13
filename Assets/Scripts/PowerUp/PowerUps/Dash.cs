using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Dash : MonoBehaviour, IPressReleaseAction{
    [SerializeField] InputActionManager playerInput;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] GameObject forwardReference; 
    bool canDash = true;
    [SerializeField] float dashSpeed = 5;
    [SerializeField] float dashTime;
    [SerializeField] int dashRecoveryTime = 1;


    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => DashAction();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext){
        
    }

    void DashAction(){
        if(!canDash)
            return;

        canDash = false;
        DashActive(forwardReference.transform.forward.normalized, dashTime);
        CallDashAnimation();
    }

    void CallDashAnimation(){
        if(!animationManager)
            return;     
        animationManager.PlayAnimation(Animations.DashPose, 0);
    }

    async void DashActive(Vector3 direction, float dashTime) {
        while (dashTime > 0) {
            dashTime -= Time.fixedDeltaTime;
            playerRigidBody.velocity = direction * dashSpeed;
            await Task.Yield();
        }

        playerRigidBody.velocity = Vector3.zero;
        DashReload(dashRecoveryTime);
    }

    async void DashReload(int dashRecoveryTime){
        await Task.Delay(dashRecoveryTime * 1000);
        canDash = true;
    }

    void OnEnable() {
        playerInput.OnRightShoulderButtonPerformed += OnButtonPressed;
        playerInput.OnRightShoulderButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnRightShoulderButtonPerformed -= OnButtonPressed;
        playerInput.OnRightShoulderButtonCanceled -= OnButtonReleased;
    }
}
