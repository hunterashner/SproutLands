using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour, ICollectible
{
    public static event LogCollected OnLogCollected;
    public delegate void LogCollected(ItemData itemData);
    public ItemData LogData;
    public void Collect(){
        Destroy(gameObject);
        OnLogCollected?.Invoke(LogData);
    }
}
