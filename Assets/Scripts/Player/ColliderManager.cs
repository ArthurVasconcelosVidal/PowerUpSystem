using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour{
    void OnTriggerEnter(Collider other) {
        PlayerManager.instance.InteractiveObject = other.gameObject;    
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject == PlayerManager.instance.InteractiveObject)
            PlayerManager.instance.InteractiveObject = null;
    }
}
