using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour, IInteractBehaviour{
    public void InteractionBehaviour(){
        PlayerManager.instance.ActionManager.GetWeapon(GetComponent<IWeapon>());
    }
}
