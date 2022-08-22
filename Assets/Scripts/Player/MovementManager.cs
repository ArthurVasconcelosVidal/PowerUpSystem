using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour{
        
    Vector3 direction = Vector3.zero;
    [SerializeField] Animator playerAnimator;
    [SerializeField] InputActionManager inputActionManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationVelocity;
    public Vector3 RealPlayerDirection { get { return direction; } }

    void FixedUpdate(){
        direction = ObjectRelatedDirection(inputActionManager.LeftStickValue, Camera.main.gameObject);
        if (direction != Vector3.zero){  
            MovePlayer();
            RotatePlayer();
        } 
        WalkAnimation();
    }

    Vector3 ObjectRelatedDirection(Vector2 inputDirection, GameObject relatedObject){
        var forwardDirection = Vector3.ProjectOnPlane(relatedObject.transform.forward, transform.up);
        var rightDirection = Vector3.ProjectOnPlane(relatedObject.transform.right, transform.up);
        Vector3 finalDirection = forwardDirection * inputDirection.y + rightDirection * inputDirection.x;
        return finalDirection.normalized;
    }

    void MovePlayer() => rigidbody.MovePosition(transform.position + direction * inputActionManager.LeftStickValue.sqrMagnitude * movementSpeed * Time.fixedDeltaTime);

    void RotatePlayer(){
        var newRotation = Quaternion.LookRotation(direction, meshObject.transform.up); 
        meshObject.transform.rotation = Quaternion.Lerp(meshObject.transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime);
    }

    public void WalkAnimation() {
		playerAnimator.SetFloat("MovVelocity", inputActionManager.LeftStickValue.sqrMagnitude);
	}

    //Debug
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, direction * 5);
    }
}
