using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDash : Dash{
    [SerializeField] AttackManager attackManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] GameObject ballMesh;
    [SerializeField] float damage;
    [SerializeField] float forceImpact;
    [SerializeField] ElementType elementType;

    override protected void DashAction(){
        if(canDash){
            DashFireAttackTrigger();
            EnableBallMesh(true);
        }
        base.DashAction();
    }

    protected override void EndDashBehavior(){
        base.EndDashBehavior();
        attackManager.EnableAttackTrigger(false);
        EnableBallMesh(false);
    }

    void DashFireAttackTrigger(){
        const float COLLISION_RANGE = 0.8f;
        attackManager.EnableAttackTrigger(true, damage, forceImpact, elementType, COLLISION_RANGE);
    }

    void EnableBallMesh(bool enable){
        meshObject.SetActive(!enable);
        ballMesh.SetActive(enable);
    }
}
