using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackInteraction{

    void AttackInteraction(GameObject whoIsAttacking, float damage = 0);
    
}
