using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ProjectileBomb : MonoBehaviour{

    public float TimeToExplode {get; set;}
    public float TimeInExplosion {get; set;}
    [SerializeField] Collider explosionCollider;

    public void StartExplosionProcess(float timeToExplode, float timeInExplosion){
        TimeToExplode = timeToExplode;
        TimeInExplosion = timeInExplosion;
        ExplodeTimer();
    }

    async void ExplodeTimer(){
        await Task.Delay((int)(TimeToExplode*1000));
        ExplodeBehaviour();
    }

    async void ExplodeBehaviour(){
        explosionCollider.enabled = true;
        await Task.Delay((int)(TimeInExplosion*1000));
        explosionCollider.enabled = false;
        EndBombBehaviour();
    }
    
    void EndBombBehaviour(){
        Destroy(this.gameObject);
    }

    /*
        TODO:
            - Explosion effect
            - Explosion Attack
    */

}
