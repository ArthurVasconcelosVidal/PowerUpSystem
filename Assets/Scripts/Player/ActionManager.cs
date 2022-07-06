using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour{
    InputActionManager playerInputManager;

    private void Awake() {
        playerInputManager = PlayerManager.instance.InputActionManager;

        playerInputManager.southButtonBehaviour += ActionButtonBehaviour;
        playerInputManager.westButtonBehaviour += AttackBehaviour;
    }

    public void ActionButtonBehaviour(InputAction.CallbackContext buttonContext){
        if(PlayerManager.instance.InteractiveObject) 
                PlayerManager.instance.InteractiveObject.GetComponent<IInteractBehaviour>().InteractionBehaviour();
            else{
                Debug.Log("Jump");
            }

        Debug.Log($"Button Value: {buttonContext.ReadValue<float>()}");
    }

    public void AttackBehaviour(InputAction.CallbackContext buttonContext){
        if(PlayerManager.instance.WeaponManager.ActualWeapon != null)
            PlayerManager.instance.WeaponManager.ActualWeapon.NormalWeaponUse();
    }
}
