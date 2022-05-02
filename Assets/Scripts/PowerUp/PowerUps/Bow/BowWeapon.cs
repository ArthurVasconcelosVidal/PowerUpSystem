using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructLibrary;

public class BowWeapon :MonoBehaviour, IWeapon{
    [SerializeField] GameObject bowProjectilePrefab;    
    public WeaponType Weapon { get => WeaponType.bow; }
    MinMaxFloat shootForceBounds = new MinMaxFloat(0, 10);
    public void NormalWeaponUse(){
        var arrow = Instantiate(bowProjectilePrefab, PlayerManager.instance.SpawnProjectilePoint.transform.position, PlayerManager.instance.MeshObject.transform.rotation);
        arrow.GetComponent<BowProjectile>().Initialize(PlayerManager.instance.MeshObject.transform.forward, shootForceBounds, shootForceBounds.Max/2);
    }

    public void RespawnPowerUp(){
        throw new System.NotImplementedException();
    }

    public void SpecialWeaponUse(){
        throw new System.NotImplementedException();
    }
}
