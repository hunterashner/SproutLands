using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GatherableEventHandler : MonoBehaviour
{
    private GameObject targetGatherable;
    public static event Action OnTreeTakeDamage;
    void OnEnable(){
        Gatherer.OnAllowGatherableDamage += EnableGatherableDamage;
        Gatherer.OnDisallowGatherableDamage += DisableGatherableDamage;
        PlayerInputManager.OnConfirmFullAnimation += DetectPlayerGathering;
    }

    void OnDisable(){
        Gatherer.OnAllowGatherableDamage -= EnableGatherableDamage;
        Gatherer.OnDisallowGatherableDamage -= DisableGatherableDamage;
        PlayerInputManager.OnConfirmFullAnimation -= DetectPlayerGathering;
    }
    void EnableGatherableDamage(GameObject objectToDamage){
        targetGatherable = objectToDamage;
    }

    void DisableGatherableDamage(GameObject outOfRangeObject){
        targetGatherable = null;
    }

    void DetectPlayerGathering(bool fullGatherAnimationCompleted){
        if(fullGatherAnimationCompleted){
            if(targetGatherable != null){
            IGatherable gatherable = targetGatherable.GetComponent<IGatherable>();
            if(gatherable != null){
                Debug.Log("applying gathering damage");
                OnTreeTakeDamage?.Invoke();
                gatherable.TakeDamage(45.0f);
                }
            }
        } else { return; }
    }
}
