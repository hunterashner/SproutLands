using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemManger : MonoBehaviour
{
    public Animator anim;

    void Start(){
        UnequipAll();
    }

    void OnEnable(){
        PlayerInputManager.OnEquippedItemSelection += HandleAnimationType;
        PlayerInputManager.OnUseEquippedItem += HandleItemUseAnimation;
    }

    void OnDisable(){
        PlayerInputManager.OnEquippedItemSelection -= HandleAnimationType;
        PlayerInputManager.OnUseEquippedItem -= HandleItemUseAnimation;
    }

    void HandleAnimationType(string animationType){
        switch(animationType){
            case "Unequipped":
                UnequipAll();
                break;
            case "Axe":
                UnequipAll();
                anim.SetBool("AxeEquipped", true);
                break;
            case "WateringCan":
                UnequipAll();
                anim.SetBool("WateringCanEquipped", true);
                break;
            case "Hoe":
                UnequipAll();
                anim.SetBool("HoeEquipped", true);
                break;
        }
    }

    void UnequipAll(){
        anim.SetBool("AxeEquipped", false);
        anim.SetBool("HoeEquipped", false);
        anim.SetBool("WateringCanEquipped", false);
    }

    void HandleItemUseAnimation(bool itemUsed){
        if(itemUsed){
            anim.SetBool("UsingEquippedObject", true);
        } else {
            anim.SetBool("UsingEquippedObject", false);
        }
    }
}
