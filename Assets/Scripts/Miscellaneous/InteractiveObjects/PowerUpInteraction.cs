using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType{
    bow
}
public class PowerUpInteraction : MonoBehaviour, IInteractBehaviour{
    [SerializeField] WeaponType weaponType;
    public void InteractionBehaviour(){
        switch (weaponType){
            case WeaponType.bow:
                PlayerManager.instance.ActionManager.GetWeapon(new BowWeapon());
                break;
            default:
                break;
        }    
    }
}
