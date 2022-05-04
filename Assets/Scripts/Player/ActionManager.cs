using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour{

    private void Awake() {
        PlayerManager.instance.InputManager.southButtonBehaviour += ActionButtonBehaviour;
        PlayerManager.instance.InputManager.westButtonBehaviour += AttackBehaviour;
    }

    public void ActionButtonBehaviour(float buttonValue){
        if(PlayerManager.instance.InteractiveObject) 
                PlayerManager.instance.InteractiveObject.GetComponent<IInteractBehaviour>().InteractionBehaviour();
            else{
                Debug.Log("Jump");
            }

        Debug.Log($"Button Value: {buttonValue}");
    }

    public void AttackBehaviour(float buttonValue){
        if(PlayerManager.instance.WeaponManager.ActualWeapon != null)
            PlayerManager.instance.WeaponManager.ActualWeapon.NormalWeaponUse();
    }
}
