using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackAttackInteraction : MonoBehaviour, IAttackInteraction{
    public void AttackInteraction(GameObject whoIsAttacking, float damage, float forceImpact, ElementType elementType = ElementType.Normal){
        EnemyManager enemyManager;
        const float BASE_UP_DIRECTION_FORCE = 1.5f;
        if(TryGetComponent<EnemyManager>(out enemyManager)){
            //TODO
            //Pass the damage information to the enemy
            //Can make this in the base class and use Inheritance to use the base class behavior in each son member 
        }
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        var direction = (transform.position - whoIsAttacking.transform.position).normalized;
        rigidbody.AddForce(((transform.up * BASE_UP_DIRECTION_FORCE) + direction) * forceImpact, ForceMode.Impulse);
        Debug.Log("Who is attacking name: " + whoIsAttacking.name);
    }
}
