using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WateringCan : MonoBehaviour, ICollectible
{
    public static event WateringCanCollected OnWateringCanCollected;
    public delegate void WateringCanCollected(ItemData itemData);
    public ItemData wateringCanData;
    public void Collect(){
        Destroy(gameObject);
        OnWateringCanCollected?.Invoke(wateringCanData);
    }
}
