using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionBehahviour : MonoBehaviour{
    [SerializeField] string playerTag;
    InputActionManager PlayerInput { get => PlayerManager.instance.InputActionManager; }

    void InteractBehaviour(object sender, InputAction.CallbackContext context){
        Debug.Log($"interagindo: {this.gameObject.name}");
        GetComponent<IinteractionBehaviour>().InteractionBehahviour();
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(playerTag))
            PlayerInput.OnSouthPrimaryButtonPerformed += InteractBehaviour;
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag(playerTag))
            PlayerInput.OnSouthPrimaryButtonPerformed -= InteractBehaviour;
    }
}
