using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDash : Dash{
    [SerializeField] AttackManager attackManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] GameObject ballMesh;
    [SerializeField] AttackInfo attackInfo;

    override protected void DashAction(){
        if(canDash){
            DashFireAttackTrigger();
            EnableBallMesh(true);
        }
        base.DashAction();
    }

    protected override void EndDashBehavior(){
        base.EndDashBehavior();
        attackManager.DisableAttackTrigger();
        EnableBallMesh(false);
    }

    void DashFireAttackTrigger(){
        const float COLLISION_RANGE = 0.8f;
        attackManager.EnableAttackTrigger(attackInfo, COLLISION_RANGE);
    }

    void EnableBallMesh(bool enable){
        meshObject.SetActive(!enable);
        ballMesh.SetActive(enable);
    }
}
