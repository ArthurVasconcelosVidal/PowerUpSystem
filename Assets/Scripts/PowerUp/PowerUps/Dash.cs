using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour, IPressReleaseAction{
    [SerializeField] InputActionManager playerInput;
    [SerializeField] float dashDistance = 4;

    public void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => DashAction();

    public void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext) => Debug.Log("Fisnish");

    void DashAction(){
        Vector3 direction = ObjectRelatedDirection(playerInput.LeftStickValue, Camera.main.gameObject);
        
        if(direction == Vector3.zero)
            return;
        

    }

    Vector3 ObjectRelatedDirection(Vector2 inputDirection, GameObject relatedObject){
        var forwardDirection = Vector3.ProjectOnPlane(relatedObject.transform.forward, transform.up);
        var rightDirection = Vector3.ProjectOnPlane(relatedObject.transform.right, transform.up);
        Vector3 finalDirection = forwardDirection * inputDirection.y + rightDirection * inputDirection.x;
        return finalDirection.normalized;
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
