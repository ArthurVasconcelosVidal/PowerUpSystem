using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour{
    
    GameObject AttackTriggerObject {get => this.gameObject;}
    SphereCollider TriggerCollider {get => GetComponent<SphereCollider>();}
    float TriggerRadius {get;set;}
    AttackInfo attackInfo;
    const float BASE_TRIGGER_RADIUS = 1.3f;

    public void EnableAttackTrigger(AttackInfo attackInfo, float baseTriggerRadius = BASE_TRIGGER_RADIUS){
        this.attackInfo = attackInfo;
        TriggerCollider.radius = baseTriggerRadius;
        AttackTriggerObject.SetActive(true);
    }

    public void DisableAttackTrigger(){
        attackInfo = null;
        AttackTriggerObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        Attack(other.gameObject, attackInfo);
    }

    public void Attack(GameObject attackedObject, AttackInfo attackInfo){
        IAttackInteraction objectAttacked;
        if (attackedObject.TryGetComponent<IAttackInteraction>(out objectAttacked))
            objectAttacked.AttackInteraction(this.gameObject, attackInfo.damage, attackInfo.forceImpact, attackInfo.elementType);
    }


}
