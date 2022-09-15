using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour{
    void OnTriggerEnter(Collider other) {
        IAttackInteraction objectAttacked;
        if (other.gameObject.TryGetComponent<IAttackInteraction>(out objectAttacked))
            objectAttacked.AttackInteraction(this.gameObject);
    }
}
