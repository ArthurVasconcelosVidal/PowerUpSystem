using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackInteraction{

    void AttackInteraction(GameObject whoIsAttacking, float damage, float forceImpact, ElementType elementType = ElementType.Normal);
    
}
