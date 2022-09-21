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
    [SerializeField] float increasingSpeedFactor = 6;
    float speed;
    float animValue;
    const float INPUT_THRESHOLD = 0.9f;
    [SerializeField] float rotationVelocity;
    [SerializeField] bool isRunning = false;
    public Vector3 RealPlayerDirection { get { return direction; } }

    void FixedUpdate(){
        direction = ObjectRelatedDirection(inputActionManager.LeftStickValue.normalized, Camera.main.gameObject);
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
        if(!isRunning)
            speed = movementSpeed;
        else if(speed < runningSpeed && inputActionManager.LeftStickValue.sqrMagnitude > INPUT_THRESHOLD)
            speed += increasingSpeedFactor * Time.fixedDeltaTime;

        speed = Mathf.Clamp(speed, 0, runningSpeed);
        rigidbody.MovePosition(transform.position + direction * inputActionManager.LeftStickValue.sqrMagnitude * speed * Time.fixedDeltaTime);
    }

    void RotatePlayer(){
        var newRotation = Quaternion.LookRotation(direction, meshObject.transform.up); 
        meshObject.transform.rotation = Quaternion.Lerp(meshObject.transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime);
    }

    public void WalkAnimation(bool isRunning){
        const float RUNNING_ANIM_VALUE = 2;
        if(!isRunning && animValue > inputActionManager.LeftStickValue.sqrMagnitude){
            animValue -= increasingSpeedFactor * Time.fixedDeltaTime;
            animValue = Mathf.Clamp(animValue, inputActionManager.LeftStickValue.sqrMagnitude, RUNNING_ANIM_VALUE);
        }
        else if(!isRunning || inputActionManager.LeftStickValue.sqrMagnitude == 0){
            animValue = inputActionManager.LeftStickValue.sqrMagnitude;
        }
        else if(inputActionManager.LeftStickValue.sqrMagnitude > INPUT_THRESHOLD){
            animValue += increasingSpeedFactor * Time.fixedDeltaTime;
            animValue = Mathf.Clamp(animValue, INPUT_THRESHOLD, RUNNING_ANIM_VALUE);
        }
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
        isRunning = false;
    }
}
