using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AttackInfo", order = 2)]
public class AttackInfo : ScriptableObject{
    public float damage;
    public float forceImpact;
    public ElementType elementType;
}
