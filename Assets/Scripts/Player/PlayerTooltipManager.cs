using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTooltipManager : MonoBehaviour
{
    public Canvas tooltipCanvas;
    public TextMeshProUGUI tooltipTitle;
    public TextMeshProUGUI tooltipTip;
    void OnEnable(){
        Interactor.OnWithinInteractionRange += DispatchTooltip;
        BoatBehavior.OnHideTooltip += ToggleTooltipDisplay;
    }

    void OnDisable(){
        Interactor.OnWithinInteractionRange -= DispatchTooltip;
        BoatBehavior.OnHideTooltip -= ToggleTooltipDisplay;
    }

    void DispatchTooltip(bool showTooltip, Tooltip toShow){
        switch(showTooltip){
            case true:
            RenderTooltipToDisplay(toShow);
            break;

            case false:
            ToggleTooltipDisplay();
            break;
        }
    }

    void RenderTooltipToDisplay(Tooltip tooltip){
        string title = tooltip.tooltipData.tooltipType;
        string tip = tooltip.tooltipData.tooltipText;
        tooltipTitle.text = title;
        tooltipTip.text = tip;
        ToggleTooltipDisplay();
    }

    void ToggleTooltipDisplay(){
        tooltipCanvas.enabled = !tooltipCanvas.enabled;
    }
}
