using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StorageChest : MonoBehaviour, IInteractable
{
    public Tooltip _tooltip;
    public Canvas _storageChestCanvas;
    public Sprite chestOpenSprite;
    public Sprite chestClosedSprite;
    public SpriteRenderer spriteRenderer;
    public bool chestOpen;

    public GameObject storageChestSlot;
    public GameObject storageChestBackground;

    //observables
    public static event Action<bool> OnChestToggle;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chestClosedSprite;
    }
    public void Interact(){
        ToggleChest();
        _storageChestCanvas.enabled = !_storageChestCanvas.enabled;
    }

    public void FinishInteraction(){
        ToggleChest();
        _storageChestCanvas.enabled = !_storageChestCanvas.enabled;
    }

    public Tooltip sendInteractionTooltip(){
        return _tooltip;
    }

    void ToggleChest(){
        //play opening animation
        chestOpen = !chestOpen;
        if(chestOpen){
            spriteRenderer.sprite = chestOpenSprite;
            OnChestToggle?.Invoke(true);
        } else {
            spriteRenderer.sprite = chestClosedSprite;
            OnChestToggle?.Invoke(false);
        }
    }
}
