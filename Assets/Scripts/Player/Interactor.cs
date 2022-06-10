using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Interactor : MonoBehaviour
{
    private Tooltip tooltip;
    public static event Action<bool, Tooltip> OnWithinInteractionRange;
    void OnTriggerEnter2D(Collider2D collision){
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if(interactable != null){
            tooltip = interactable.sendInteractionTooltip();
            if(tooltip != null){
            OnWithinInteractionRange?.Invoke(true, tooltip);
            interactable.Interact();
            }
        } 
    }

    void OnTriggerExit2D(Collider2D collision){
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if(interactable == null) { return; } else {
            Tooltip tooltip = null;
            OnWithinInteractionRange?.Invoke(false, tooltip);
            interactable.FinishInteraction();
        }
    }

    public bool getInteractionState(bool interactionState){
        return interactionState;
    }
}
