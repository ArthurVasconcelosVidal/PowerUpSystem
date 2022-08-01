using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour, IinteractionBehaviour{
    [SerializeField] WeaponType weaponType;
    public void InteractionBehahviour(){
        switch (weaponType){
            case WeaponType.bow:
                Debug.Log("Bow");
                break;
            case WeaponType.none:
                Debug.Log("None");
                break;
        }
    }
}
