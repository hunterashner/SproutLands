using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, ICollectible
{
    public static event AxeCollected OnAxeCollected;
    public delegate void AxeCollected(ItemData itemData);

    //private float floatSpan = 2.0f;
    //private float speed = 1.0f; 
    public ItemData axeData;
    public void Collect(){
        Destroy(gameObject);
        OnAxeCollected?.Invoke(axeData);
    }
}
