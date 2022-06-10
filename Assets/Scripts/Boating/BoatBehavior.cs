using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BoatBehavior : MonoBehaviour, IInteractable, IPilotable
{
    public Animator _anim;
    public GameObject _seat;
    public SpriteRenderer _spriteRenderer;
    public Sprite _boatDockedSprite;
    public Sprite _boatPilotedSprite;
    public bool docked;
    public bool isDockable;
    public static event Action<GameObject> OnEnterVehicle;
    public static event Action OnHideTooltip;
    public static event Action OnExitVehicle;

    public Tooltip boatTooltipDocked;
    public Tooltip boatTooltipPiloted;

    void Start(){
        gameObject.GetComponent<BoatMovement>().enabled = false;
    }

    void OnEnable(){
        PlayerInputManager.OnUseKeyPress += EnterVehicle;
        Pilot.OnAllowBoatTravel += EnableBoatControls;
        Pilot.OnPreventBoatTravel += DisableBoatConrols;
    }

    void OnDisable(){
        PlayerInputManager.OnUseKeyPress -= EnterVehicle;
        Pilot.OnAllowBoatTravel -= EnableBoatControls;
        Pilot.OnPreventBoatTravel -= DisableBoatConrols;
    }

    void Update(){
        if(!docked){
            _anim.SetBool("Docked", false);
        } else {
            _anim.SetBool("Docked", true);
        }

    }

    public void ToggleBoatDocked(){
        docked = !docked;
    }

    public void Interact(){
        docked = !docked;
    }

    public void FinishInteraction(){
        docked = !docked;
    }

    public Tooltip sendInteractionTooltip(){
        return boatTooltipDocked;
    }

    public void EnterVehicle(){
        if(docked){ return; }
        else {
            OnEnterVehicle?.Invoke(_seat);
        }
    }

    public void ExitVehicle(){
        OnExitVehicle?.Invoke();
    }

    public void EnableBoatControls(){
        gameObject.GetComponent<BoatMovement>().enabled = true;
    }
    public void DisableBoatConrols(){
        GetComponent<BoatMovement>().enabled = false;
    }
}
