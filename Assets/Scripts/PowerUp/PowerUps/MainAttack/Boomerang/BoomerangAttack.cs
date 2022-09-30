using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class BoomerangAttack : MainAttack{
    [SerializeField] GameObject boomerangPrefab;
    [SerializeField] float timeToReload;
    bool canShootBoomerang = true;


    void ShootBoomerang(){
        if(canShootBoomerang){
            canShootBoomerang = false;
            BoomerangReload(timeToReload);
        }
    }

    async void BoomerangBehavior(){
        float percentage = 0;
        while (percentage != 1){
            await Task.Yield();
        }
    }

    async void BoomerangReload(float recoveryTime){
        await Task.Delay((int)(recoveryTime*1000));
        canShootBoomerang = true;
    }

    public override void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext) => ShootBoomerang();
}
