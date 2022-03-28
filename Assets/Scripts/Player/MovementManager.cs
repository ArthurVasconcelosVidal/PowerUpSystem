using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour{

    Vector3 direction = Vector3.zero;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationVelocity;

    public Vector3 RealPlayerDirection { get { return direction; } }
    
    void Start(){
        
    }

    void FixedUpdate(){
        direction = ObjectRelatedDirection(PlayerManager.instance.InputManager.LeftStickValue, Camera.main.gameObject);
        MovePlayer();
        RotatePlayer();
    }

    Vector3 ObjectRelatedDirection(Vector2 inputDirection, GameObject relatedObject){
        var forwardDirection = Vector3.ProjectOnPlane(relatedObject.transform.forward, transform.up);
        var rightDirection = Vector3.ProjectOnPlane(relatedObject.transform.right, transform.up);
        var finalDirection = forwardDirection * inputDirection.y + rightDirection * inputDirection.x;
        return finalDirection.normalized;
    }

    void MovePlayer() => PlayerManager.instance.CharacterRigidbody.MovePosition(transform.position + direction * movementSpeed  * Time.fixedDeltaTime);  

    void RotatePlayer(){
        var newRotation = Quaternion.FromToRotation(PlayerManager.instance.MeshObject.transform.forward, direction) * PlayerManager.instance.MeshObject.transform.rotation; 
        PlayerManager.instance.MeshObject.transform.rotation = Quaternion.Lerp(PlayerManager.instance.MeshObject.transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime);
    }

    //Debug
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if(direction != Vector3.zero) Gizmos.DrawLine(transform.position, direction * 5);
    }
}
