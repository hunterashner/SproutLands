using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;

    public void ClearSlot(){
        icon.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item){
        if(item == null){
            //Debug.Log("null slot drawn");
            ClearSlot();
            return;
        } else {
            //Debug.Log("draw slot called");
            icon.enabled = true;
            stackSizeText.enabled = true;

            icon.sprite = item.itemData.itemIcon;
            stackSizeText.text = item.stackSize.ToString();
        }
    }
}
