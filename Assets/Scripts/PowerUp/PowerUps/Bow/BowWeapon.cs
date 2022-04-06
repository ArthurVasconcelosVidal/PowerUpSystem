using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon :MonoBehaviour, IWeapon{
    [SerializeField] GameObject bowProjectilePrefab;

    public WeaponType Weapon { get => WeaponType.bow; }

    public void NormalWeaponUse(){
        var arrow = Instantiate(bowProjectilePrefab, PlayerManager.instance.MeshObject.transform.position, PlayerManager.instance.MeshObject.transform.rotation);
        arrow.GetComponent<BowProjectile>().Initialize(PlayerManager.instance.MeshObject.transform.forward, 1f, 8);
    }

    public void RespawnPowerUp(){
        throw new System.NotImplementedException();
    }

    public void SpecialWeaponUse(){
        throw new System.NotImplementedException();
    }
}
