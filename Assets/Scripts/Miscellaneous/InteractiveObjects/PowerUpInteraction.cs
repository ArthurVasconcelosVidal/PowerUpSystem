using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour, IInteractBehaviour{
    [SerializeField] WeaponType weaponType;
    public void InteractionBehaviour() => PlayerManager.instance.WeaponManager.ChangeWeapon(weaponType);
}
