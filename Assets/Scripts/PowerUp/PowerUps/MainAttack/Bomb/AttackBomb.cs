using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
public class AttackBomb : MainAttack{

    GameObject MeshObject {get => PlayerManager.instance.MeshObject; }

    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float timeToExplodeBomb;
    [SerializeField] float timeInExplosion;
    [SerializeField] float throwBombForce;
    [SerializeField] float timeToReload;
    bool canShootBomb = true;
    
    public override void OnButtonPressed(InputAction.CallbackContext buttonContext) => ShootBomb();

    void ShootBomb(){
        if(canShootBomb){
            canShootBomb = false;
            BombReload(timeToReload);
            var bomb = SpawnBomb();
            StartBomb(bomb);
        }
    }

    async void BombReload(float timeToReload){
        await Task.Delay((int)(timeToReload*1000));
        canShootBomb = true;
    }

    GameObject SpawnBomb(){
        GameObject bombObj = Instantiate(bombPrefab,spawnPoint.transform.position, Quaternion.identity);
        return bombObj;
    }

    void StartBomb(GameObject bomb){
        ThrowBomb(bomb);
        ProjectileBomb bombProj = bomb.GetComponent<ProjectileBomb>();
        bombProj.StartExplosionProcess(timeToExplodeBomb, timeInExplosion);
    }

    void ThrowBomb(GameObject bombObj){
        Rigidbody bombRb = bombObj.GetComponent<Rigidbody>();
        Vector3 direction = (MeshObject.transform.forward + MeshObject.transform.up).normalized; 
        bombRb.AddForce(direction * throwBombForce, ForceMode.Impulse);
    }
}
