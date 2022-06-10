using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryToggle : MonoBehaviour
{
    public Canvas _inventoryCanvas;
    void OnEnable(){
        //subscribe to inventory toggle
        PlayerUIObservable.OnShowInventory += TogglePlayerInventory;
    }

    void OnDisable(){
        PlayerUIObservable.OnShowInventory -= TogglePlayerInventory;
    }

    void TogglePlayerInventory(){
        _inventoryCanvas.enabled = !_inventoryCanvas.enabled;
    }
}
