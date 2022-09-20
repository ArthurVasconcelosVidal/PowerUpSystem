using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour{
    float Damage {get;set;}
    float ForceImpact {get;set;}
    ElementType ElementType {get;set;}
    GameObject AttackTriggerObject {get => this.gameObject;}
    SphereCollider TriggerCollider {get => GetComponent<SphereCollider>();}
    float TriggerRadius {get;set;}
    const float BASE_TRIGGER_RADIUS = 1.3f;
    public void EnableAttackTrigger(bool enable,float damage = 0, float forceImpact = 0, ElementType elementType = ElementType.Normal, float baseTriggerRadius = BASE_TRIGGER_RADIUS){
        if(enable){
            Damage = damage;
            ForceImpact = forceImpact;
            ElementType = elementType;
            TriggerCollider.radius = baseTriggerRadius;
        }
        AttackTriggerObject.SetActive(enable);
    }

    void OnTriggerEnter(Collider other) {
        IAttackInteraction objectAttacked;
        if (other.gameObject.TryGetComponent<IAttackInteraction>(out objectAttacked))
            objectAttacked.AttackInteraction(this.gameObject, Damage, ForceImpact, ElementType);
    }


}
