using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
   public static event Action <List<InventoryItem>> OnInventoryChange;
   public List<InventoryItem> inventory = new List<InventoryItem>();
   private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();
   
   private void OnEnable(){
       //handle item collection and add items to inventory
       WateringCan.OnWateringCanCollected += Add;
       Hoe.OnHoeCollected += Add;
       Axe.OnAxeCollected += Add;
       Log.OnLogCollected += Add;
       Stick.OnStickCollected += Add;
       Stone.OnStoneCollected += Add;
   }

   private void OnDisable(){
       WateringCan.OnWateringCanCollected -= Add;
       Hoe.OnHoeCollected -= Add;
       Axe.OnAxeCollected -= Add;
       Log.OnLogCollected -= Add;
       Stick.OnStickCollected -= Add;
       Stone.OnStoneCollected -= Add;
   }
   public void Add(ItemData itemData) {
       if(itemDictionary.TryGetValue(itemData, out InventoryItem item)){
           item.AddToStack();
           //Debug.Log($"{item.itemData.itemName} total stack is now {item.stackSize}");
           OnInventoryChange?.Invoke(inventory);
       } else {
           InventoryItem newItem = new InventoryItem(itemData);
           inventory.Add(newItem);
           itemDictionary.Add(itemData, newItem);
           //Debug.Log($"you found your first {newItem.itemData.itemName}");
           OnInventoryChange?.Invoke(inventory);
       }
   }

   public void Remove(ItemData itemData){
       if(itemDictionary.TryGetValue(itemData, out InventoryItem item)){
           item.RemoveFromStack();
           if(item.stackSize == 0){
               inventory.Remove(item);
               itemDictionary.Remove(itemData);
           }
           OnInventoryChange?.Invoke(inventory);
       }
   }
}
