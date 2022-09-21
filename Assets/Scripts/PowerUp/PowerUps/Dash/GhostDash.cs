using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDash : Dash{
    [SerializeField] Material normalMaterial;
    [SerializeField] Material ghostMaterial;
    [SerializeField] GameObject meshModel;

    override protected void DashAction(){
        if(canDash){
            gameObject.layer = (int)Layers.GhostLayer;
            EnableGhostMaterial(true);
        }
        base.DashAction();
    }
    
    void EnableGhostMaterial(bool enable){
        Material targetMaterial;
        if(enable) targetMaterial = ghostMaterial;
        else targetMaterial = normalMaterial;

        var skinnedRender = meshModel.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var modelPiece in skinnedRender){
            if(modelPiece.sharedMaterial == ghostMaterial || modelPiece.sharedMaterial == normalMaterial) 
                modelPiece.material = targetMaterial;
        }
    }

    protected override void EndDashBehavior(){
        base.EndDashBehavior();
        gameObject.layer = (int)Layers.Default;
        EnableGhostMaterial(false);
    }
}
