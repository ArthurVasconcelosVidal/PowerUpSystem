using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour, IPressReleaseAction{
        
    Vector3 direction = Vector3.zero;
    [SerializeField] Animator playerAnimator;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float movementSpeed;
    [SerializeField] float runningSpeed;
    [SerializeField] float rotationVelocity;
    [SerializeField] bool isRunning = false;
    public Vector3 RealPlayerDirection { get { return direction; } }

    void FixedUpdate(){
        direction = ObjectRelatedDirection(inputActionManager.LeftStickValue, Camera.main.gameObject);
        if (direction != Vector3.zero){  
            MovePlayer();
            RotatePlayer();
        } 
        WalkAnimation(isRunning);
    }

    Vector3 ObjectRelatedDirection(Vector2 inputDirection, GameObject relatedObject){
        var forwardDirection = Vector3.ProjectOnPlane(relatedObject.transform.forward, transform.up);
        var rightDirection = Vector3.ProjectOnPlane(relatedObject.transform.right, transform.up);
        Vector3 finalDirection = forwardDirection * inputDirection.y + rightDirection * inputDirection.x;
        return finalDirection.normalized;
    }

    void MovePlayer(){
        if (isRunning) 
            rigidbody.MovePosition(transform.position + direction * inputActionManager.LeftStickValue.sqrMagnitude * runningSpeed * Time.fixedDeltaTime);
        else
            rigidbody.MovePosition(transform.position + direction * inputActionManager.LeftStickValue.sqrMagnitude * movementSpeed * Time.fixedDeltaTime);
    }

    void RotatePlayer(){
        var newRotation = Quaternion.LookRotation(direction, meshObject.transform.up); 
        meshObject.transform.rotation = Quaternion.Lerp(meshObject.transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime);
    }

    public void WalkAnimation(bool isRunning){
        float animValue =  inputActionManager.LeftStickValue.sqrMagnitude;
        const float RUNNING_ANIM_VALUE = 2;
        if (isRunning && animValue > 0.9) animValue = RUNNING_ANIM_VALUE; 
		playerAnimator.SetFloat("MovVelocity", animValue);
	}
    //Debug
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, direction * 5);
    }

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => isRunning = true;

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => isRunning = false;

    void OnEnable() {
        inputActionManager.OnWestButtonPerformed += OnButtonPressed;
        inputActionManager.OnWestButtonCanceled += OnButtonReleased;
    }

    void OnDisable() {
        inputActionManager.OnWestButtonPerformed -= OnButtonPressed;
        inputActionManager.OnWestButtonCanceled -= OnButtonReleased;
    }
}
