using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour{

    Vector3 direction = Vector3.zero;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationVelocity;
    public Vector3 RealPlayerDirection { get { return direction; } }
    PlayerManager PlayerManager { get {return PlayerManager.instance; } }

    void FixedUpdate(){
        direction = ObjectRelatedDirection(PlayerManager.InputActionManager.LeftStickValue, Camera.main.gameObject);
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

    void MovePlayer() => PlayerManager.instance.CharacterRigidbody.MovePosition(transform.position + direction * PlayerManager.InputActionManager.LeftStickValue.sqrMagnitude * movementSpeed * Time.fixedDeltaTime);

    void RotatePlayer(){
        var newRotation = Quaternion.LookRotation(direction, PlayerManager.instance.MeshObject.transform.up); 
        PlayerManager.instance.MeshObject.transform.rotation = Quaternion.Lerp(PlayerManager.instance.MeshObject.transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime);
    }

    public void WalkAnimation() {
		playerAnimator.SetFloat("MovVelocity", PlayerManager.InputActionManager.LeftStickValue.sqrMagnitude);
	}

    //Debug
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, direction * 5);
    }
}
