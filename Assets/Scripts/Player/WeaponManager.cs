using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour{
    [SerializeField] IWeapon[] weapons = new IWeapon[1];
    IWeapon actualWeapon;
    public IWeapon ActualWeapon { get => actualWeapon; }

    void Awake() {
        weapons[0] = GetComponent<BowWeapon>();
    }

    public void ChangeWeapon( WeaponType weaponType ) => actualWeapon = Array.Find(weapons, weapon => weapon.Weapon == weaponType);
    
}

