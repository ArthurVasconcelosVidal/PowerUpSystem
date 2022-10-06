using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class BoomerangAttack : MainAttack{
    [SerializeField] GameObject boomerangPrefab;
    [SerializeField] float timeToReload;
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    Vector3 TargetPos {get; set;}
    bool canShootBoomerang = true;

    void ShootBoomerang(){
        if(canShootBoomerang){
            canShootBoomerang = false;
            BoomerangReload(timeToReload);
            SpawnBoomerang();
        }
    }

    void SpawnBoomerang(){
        GameObject booObj = Instantiate(boomerangPrefab, transform.position, Quaternion.identity);
        BoomerangProjectile boo = booObj.GetComponent<BoomerangProjectile>();
        if (TargetPos == null || TargetPos == Vector3.zero)
            TargetPos = transform.position + (MeshObject.transform.forward * 5); // Fix
        boo.StartBoo(transform.gameObject, TargetPos);
    }

    async void BoomerangReload(float recoveryTime){
        await Task.Delay((int)(recoveryTime*1000));
        canShootBoomerang = true;
    }

    public override void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => ShootBoomerang();
}
