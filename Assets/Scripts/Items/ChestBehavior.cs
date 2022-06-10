using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ChestBehavior : MonoBehaviour
{
    public static event Action<bool> OnChestToggle;
    public Sprite chestOpenSprite;
    public Sprite chestClosedSprite;
    public SpriteRenderer spriteRenderer;
    public bool chestOpen;

    void OnCollisionEnter2D(){
        ToggleChest();
        ObservableChestStatus();
    }

    void OnCollisionExit2D(){
        ToggleChest();
        ObservableChestStatus();
    }
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chestClosedSprite;
    }

    void ToggleChest(){
        //play opening animation
        chestOpen = !chestOpen;
        if(chestOpen){
            spriteRenderer.sprite = chestOpenSprite;
        } else {
            spriteRenderer.sprite = chestClosedSprite;
        }
    }

    public void ObservableChestStatus(){
        OnChestToggle?.Invoke(chestOpen);
    }
}
