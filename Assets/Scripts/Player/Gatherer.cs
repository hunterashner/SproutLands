using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gatherer : MonoBehaviour
{
    //Event Actions
    public static event Action<GameObject> OnAllowGatherableDamage;
    public static event Action<GameObject> OnDisallowGatherableDamage;
    void OnTriggerEnter2D(Collider2D collider){
        IGatherable gatherable = collider.GetComponent<IGatherable>();
        if(gatherable != null){
            OnAllowGatherableDamage?.Invoke(collider.gameObject);
        } else { return; }
    }

    void OnTriggerExit2D(Collider2D collider){
        IGatherable gatherable = collider.GetComponent<IGatherable>();
        if(gatherable != null){
            OnDisallowGatherableDamage?.Invoke(collider.gameObject);
        } else { return; }
    }
}
