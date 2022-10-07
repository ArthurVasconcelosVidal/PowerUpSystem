using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class BoomerangAttack : MainAttack{
    [SerializeField] GameObject boomerangPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float timeToReload;
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    bool canShootBoomerang = true;

    public override void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => ShootBoomerang();
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
            Vector3 targetPoint = GetTarget();
            boomerangProj.StartBoo(transform.gameObject, targetPoint);
    }

    Vector3 GetTarget(){
        //Implement the get target function with the Interest System mechanic
        return transform.position + (MeshObject.transform.forward * 5);
    }
}
