using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour{
    InputActionManager playerInputManager;

    private void Start() {
        playerInputManager = PlayerManager.instance.InputActionManager;

        playerInputManager.OnSouthButtonPerformed += ActionButtonBehaviour;
        playerInputManager.OnWestButtonPerformed += AttackBehaviour;
    }

    public void ActionButtonBehaviour(object sender, InputAction.CallbackContext buttonContext){
        if(PlayerManager.instance.InteractiveObject) 
            PlayerManager.instance.InteractiveObject.GetComponent<IInteractBehaviour>().InteractionBehaviour();
        else
            Debug.Log("Jump");

        Debug.Log($"Button Value: {buttonContext.ReadValue<float>()}");
    }

    public void AttackBehaviour(object sender, InputAction.CallbackContext buttonContext){
        if(PlayerManager.instance.WeaponManager.ActualWeapon != null)
            PlayerManager.instance.WeaponManager.ActualWeapon.NormalWeaponUse();
    }
}
