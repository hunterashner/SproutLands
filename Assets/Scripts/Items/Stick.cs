using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, ICollectible
{
    public static event StickCollected OnStickCollected;
    public delegate void StickCollected(ItemData itemData);
    public ItemData StickData;
    public void Collect(){
        Destroy(gameObject);
        OnStickCollected?.Invoke(StickData);
    }
}
