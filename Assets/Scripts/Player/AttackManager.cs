using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour{
    public float Damage {get;set;}
    public float ForceImpact {get;set;}
    public ElementType ElementType {get;set;}
    void OnTriggerEnter(Collider other) {
        IAttackInteraction objectAttacked;
        if (other.gameObject.TryGetComponent<IAttackInteraction>(out objectAttacked))
            objectAttacked.AttackInteraction(this.gameObject, Damage, ForceImpact, ElementType);
    }
}
