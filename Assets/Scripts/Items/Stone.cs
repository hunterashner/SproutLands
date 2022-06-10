using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, ICollectible
{
    public static event StoneCollected OnStoneCollected;
    public delegate void StoneCollected(ItemData itemData);
    public ItemData StoneData;
    public void Collect(){
        Destroy(gameObject);
        OnStoneCollected?.Invoke(StoneData);
    }
}
