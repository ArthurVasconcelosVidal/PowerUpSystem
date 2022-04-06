using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon :MonoBehaviour, IWeapon{
    [SerializeField] GameObject bowProjectilePrefab;

    public WeaponType Weapon { get => WeaponType.bow; }

    public void NormalWeaponUse(){
        throw new System.NotImplementedException();
    }

    public void RespawnPowerUp(){
        throw new System.NotImplementedException();
    }

    public void SpecialWeaponUse(){
        throw new System.NotImplementedException();
    }
}
