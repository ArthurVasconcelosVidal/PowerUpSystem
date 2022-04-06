using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon{
    public WeaponType Weapon{get;}
    public void NormalWeaponUse();
    public void SpecialWeaponUse();
    public void RespawnPowerUp();
}
