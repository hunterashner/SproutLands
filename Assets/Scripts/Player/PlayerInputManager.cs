using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInputManager : MonoBehaviour
{
    public static event Action<String> OnEquippedItemSelection;
    public static Action<bool> OnUseEquippedItem;
    public static Action<bool> OnConfirmFullAnimation;
    public static Action OnUseKeyPress;
    public static Action OnUseKeyRelease;

    public Animator _anim;

    IEnumerator WaitForFullGatherAnimation(float timeBetweenAnimations){
        Debug.Log("waiting...");
        yield return new WaitForSeconds(timeBetweenAnimations);
        Debug.Log("invoking gatherable event");
        OnConfirmFullAnimation?.Invoke(true);
    }

    void Update()
    {   //handle left clicks
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            OnUseEquippedItem?.Invoke(true);
            StartCoroutine(WaitForFullGatherAnimation(.75f));
        }

        if(Input.GetKeyUp(KeyCode.Mouse0)){
            OnUseEquippedItem?.Invoke(false);
            StopCoroutine(WaitForFullGatherAnimation(0.0f));
            OnConfirmFullAnimation?.Invoke(false);
        }
        //send to item manager to decide currently equipped item
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Axe Equipped");
            OnEquippedItemSelection?.Invoke("Axe");
        }
        if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("Currently Unequipped");
            OnEquippedItemSelection?.Invoke("Unequiped");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Watering Can Equipped");
            OnEquippedItemSelection?.Invoke("WateringCan");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Hoe Equipped");
            OnEquippedItemSelection?.Invoke("Hoe");
        }
        if(Input.GetKeyDown(KeyCode.E)){
            OnUseKeyPress?.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.E)){
            OnUseKeyRelease?.Invoke();
        }
    }
}
