using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hoe : MonoBehaviour, ICollectible
{
    public static event HoeCollected OnHoeCollected;
    public delegate void HoeCollected(ItemData itemData);
    public ItemData hoeData;
    public void Collect(){
        Destroy(gameObject);
        OnHoeCollected?.Invoke(hoeData);
    }
}
