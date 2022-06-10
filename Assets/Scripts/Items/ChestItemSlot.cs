using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestItemSlot : MonoBehaviour
{
    public TextMeshProUGUI stackSize;
    public Image itemImage;

    public void ClearSlot(){
        itemImage.enabled = false;
        stackSize.enabled = false;
    }

    public void DrawSlot(Sprite imageToDraw, string stackSizeToDraw){
        itemImage.sprite = imageToDraw;
        stackSize.text = stackSizeToDraw;
    }
}
