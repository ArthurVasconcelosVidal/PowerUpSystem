using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDash : Dash{

    [SerializeField] GameObject attackTrigger;

    override protected void DashAction(){
        base.DashAction();
        DashFireAttackTrigger();
    }

    override protected void CallDashAnimation(){

    }

    void DashFireAttackTrigger(){
        Debug.Log("Do Something");
    }
}
