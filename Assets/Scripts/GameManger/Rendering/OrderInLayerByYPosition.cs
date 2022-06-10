using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerByYPosition : MonoBehaviour
{
    void Update(){
        SpriteRenderer[] allSpriteRenderers = FindObjectsOfType<SpriteRenderer>();
        foreach(SpriteRenderer sr in allSpriteRenderers){
            sr.sortingOrder = (int)(sr.transform.position.y * -100);
        }
    }
}
