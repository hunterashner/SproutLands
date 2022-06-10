using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUIObservable : MonoBehaviour
{
    public static event Action OnShowInventory;

    void Update(){ //On Tab press toggle player inventory
        if(Input.GetKeyDown(KeyCode.Tab)){
            OnShowInventory?.Invoke();
        }
    }
}
