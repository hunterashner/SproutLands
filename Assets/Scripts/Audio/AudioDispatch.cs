using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDispatch : MonoBehaviour
{
    //references
    #region
    public AudioClip toolPickupSound;
    public AudioClip resourcePickupSound;
    public AudioClip inventoryToggleSound;
    public AudioClip chestOpenSound;
    public AudioClip chestCloseSound;
    public AudioClip woodCuttingSound;
    public AudioClip treeFallingSound;
    public AudioClip boatSpeedBoost;
    public AudioClip boatInteractionSound;
    public AudioSource audioSource;
    #endregion

    void OnAwake(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable(){
        Axe.OnAxeCollected += PlayItemPickupSound;
        Hoe.OnHoeCollected += PlayItemPickupSound;
        WateringCan.OnWateringCanCollected += PlayItemPickupSound;
        Stone.OnStoneCollected += PlayItemPickupSound;
        Stick.OnStickCollected += PlayItemPickupSound;
        Log.OnLogCollected += PlayItemPickupSound;
        PlayerUIObservable.OnShowInventory += PlayUISound;
        StorageChest.OnChestToggle += PlayChestOpenClose;
        Interactor.OnWithinInteractionRange += PlayInteractionSound;
        GatherableEventHandler.OnTreeTakeDamage += PlayWoodCuttingSound;
        BoatMovement.OnBoatSpeedBoost += PlayBoatSpeedBoostSound;
    }

    void OnDisable(){
        Axe.OnAxeCollected -= PlayItemPickupSound;
        Hoe.OnHoeCollected -= PlayItemPickupSound;
        WateringCan.OnWateringCanCollected -= PlayItemPickupSound;
        Stone.OnStoneCollected -= PlayItemPickupSound;
        Stick.OnStickCollected -= PlayItemPickupSound;
        Log.OnLogCollected -= PlayItemPickupSound;
        PlayerUIObservable.OnShowInventory -= PlayUISound;
        StorageChest.OnChestToggle -= PlayChestOpenClose;
        Interactor.OnWithinInteractionRange += PlayInteractionSound;
        GatherableEventHandler.OnTreeTakeDamage += PlayWoodCuttingSound;
        BoatMovement.OnBoatSpeedBoost -= PlayBoatSpeedBoostSound;
    }

    public void PlayItemPickupSound(ItemData item){
        //play an item pickup sound based on item name
        switch(item.itemName){
            case "Tool":
                //play tool pickup sound
                audioSource.clip = toolPickupSound;
                audioSource.Play();
                break;
            case "Resource":
                //play resource pickup sound
                audioSource.clip = toolPickupSound;
                audioSource.Play();
                break;
            case "Generic":
                //play generic pickup sound
                break;
        }
    }

    public void PlayUISound(){
        audioSource.clip = inventoryToggleSound;
        audioSource.Play();
    }

    public void PlayChestOpenClose(bool chestOpen){

        if(chestOpen){
            audioSource.clip = chestOpenSound;
            audioSource.PlayOneShot(chestOpenSound, .1f);
        } else {
            audioSource.clip = chestCloseSound;
            audioSource.PlayOneShot(chestCloseSound, .1f);
        }
    }

    public void PlayInteractionSound(bool showTooltip, Tooltip tooltip){
        if(!showTooltip) { return; }
        switch(tooltip.tooltipData.tooltipType){
            case "Boat":
            audioSource.clip = boatInteractionSound;
            audioSource.Play();
            break;
            
            case "Crafting Station":
            audioSource.clip = inventoryToggleSound;
            audioSource.Play();
            break;
        }
    }

    public void PlayWoodCuttingSound(){
        audioSource.clip = woodCuttingSound;
        audioSource.Play();
    }

    public void PlayTreeFallingSound(){
        audioSource.clip = treeFallingSound;
        audioSource.Play();
    }

    public void PlayBoatSpeedBoostSound(){
        audioSource.clip = boatSpeedBoost;
        audioSource.Play();
    }
}
