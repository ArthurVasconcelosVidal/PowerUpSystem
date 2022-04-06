using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour{

    public void ActionButtonBehaviour(){
        if(PlayerManager.instance.InteractiveObject) 
                PlayerManager.instance.InteractiveObject.GetComponent<IInteractBehaviour>().InteractionBehaviour();
            else{
                Debug.Log("Jump");
            }
    }

    public void AttackBehaviour(){
        PlayerManager.instance.WeaponManager.ActualWeapon.NormalWeaponUse();
    }
}
