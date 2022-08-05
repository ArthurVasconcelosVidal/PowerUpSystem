using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Dash : MonoBehaviour, IPressReleaseAction{
    [SerializeField] InputActionManager playerInput;
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] GameObject forwardReference; 
    bool canDash = true;
    [SerializeField] float dashSpeed = 5;
    [SerializeField] float dashTime;
    [SerializeField] int dashRecoveryTime = 1;


    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => DashAction();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => Debug.Log("Fisnish");

    void DashAction(){
        if(!canDash)
            return;
        
        DashActive(forwardReference.transform.forward.normalized, dashTime);
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
        playerInput.OnWestButtonPerformed += OnButtonPressed;
        playerInput.OnWestButtonCanceled += OnButtonReleased;
    }
    void OnDisable() {
        playerInput.OnWestButtonPerformed -= OnButtonPressed;
        playerInput.OnWestButtonCanceled -= OnButtonReleased;
    }
}
