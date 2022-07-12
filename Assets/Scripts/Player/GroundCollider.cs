using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour{
    void OnTriggerEnter(Collider other) {
        Debug.Log("ENTRO");
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("SAIU");
    }
}
