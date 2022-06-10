using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Pilot : MonoBehaviour
{
    private Vector3 grassEntryPosition;
    public static event Action OnAllowBoatTravel;
    public static event Action OnPreventBoatTravel;
    void OnEnable(){
        BoatBehavior.OnEnterVehicle += HandleVehicleEntry;
        BoatMovement.OnBoatExit += HandleVehicleExit;
    }

    void OnDisable(){
        BoatBehavior.OnEnterVehicle -= HandleVehicleEntry;
    }

    void HandleVehicleEntry(GameObject vehicle){
        grassEntryPosition = transform.position;
        foreach(MonoBehaviour c in GetComponents<MonoBehaviour>()){
            c.enabled = false;
        }
        GetComponent<Rigidbody2D>().isKinematic= true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        spriteRenderer.sortingLayerName = "AboveDefault";
        gameObject.transform.position = vehicle.transform.position;
        gameObject.transform.SetParent(vehicle.transform);
        OnAllowBoatTravel.Invoke();
    }

    void HandleVehicleExit(){
        Vector3 landingSpot = this.transform.parent.position;
        landingSpot = new Vector3(landingSpot.x, landingSpot.y + .1f, landingSpot.z);
        gameObject.transform.parent = null;
        transform.position = landingSpot;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Default";
        GetComponent<Rigidbody2D>().isKinematic = false;
        foreach(MonoBehaviour c in GetComponents<MonoBehaviour>()){
            c.enabled = true;
        }
        OnPreventBoatTravel?.Invoke();
    }
}
