using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour, IInteractable
{
    public Tooltip craftingStationTooltip;
    public Canvas craftingStationCanvas;
    public Tooltip sendInteractionTooltip(){
        return craftingStationTooltip;
    }
    public void Interact(){
        craftingStationCanvas.enabled = !craftingStationCanvas.enabled;
    }

    public void FinishInteraction(){
        craftingStationCanvas.enabled = !craftingStationCanvas.enabled;
    }
}
