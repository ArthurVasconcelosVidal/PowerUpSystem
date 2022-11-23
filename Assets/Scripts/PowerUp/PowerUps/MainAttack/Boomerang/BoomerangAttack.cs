using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class BoomerangAttack : MainAttack{
    [SerializeField] GameObject boomerangPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject basicTargetObject;
    [SerializeField] float timeToReload;
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    InterestManager InterestManager { get => PlayerManager.instance.InterestManager; }
    bool canShootBoomerang = true;

    public override void OnButtonPressed(InputAction.CallbackContext buttonContext) => ShootBoomerang();
    void ShootBoomerang(){
        if(canShootBoomerang){
            canShootBoomerang = false;
            BoomerangReload(timeToReload);
            var boomerang = SpawnBoomerang();
            StartBoomerang(boomerang);
        }
    }

    async void BoomerangReload(float recoveryTime){
        await Task.Delay((int)(recoveryTime*1000));
        canShootBoomerang = true;
    }

    GameObject SpawnBoomerang(){
        GameObject boomerang = Instantiate(boomerangPrefab, spawnPoint.transform.position, Quaternion.identity); // In a final product a pool has to be used
        return boomerang;
    }

    void StartBoomerang(GameObject boomerang){
        BoomerangProjectile boomerangProj = boomerang.GetComponent<BoomerangProjectile>();
        Transform targetPoint = GetTarget();
        boomerangProj.StartBoo(transform, targetPoint);
    }

    Transform GetTarget(){
        if (InterestManager.ClosestObject)
            return InterestManager.ClosestObject.transform;
        else
            return basicTargetObject.transform;
    }

}
