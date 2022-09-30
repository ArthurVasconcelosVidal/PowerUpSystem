using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour{
    
    [SerializeField] Rigidbody boomerangRB;
    GameObject returnObject;
    Vector3 directToFollow;
    public Vector3 DirectionToFollow{ get => directToFollow;  set{ directToFollow = value.normalized; } }
    float timeToHalfWay;
    float projectileSpeed;
    
    async void BoomerangBehavior(){
        float time = 0;
        while (time != timeToHalfWay){
            time += Time.fixedDeltaTime;
            boomerangRB.MovePosition(transform.position + DirectionToFollow * projectileSpeed * Time.fixedDeltaTime);
            await Task.Yield();
        }
    }    

}
