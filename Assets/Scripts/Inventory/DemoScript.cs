using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    
    public void PickupItem(int id)
    {
       bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true){
            Debug.Log("Item added");
        }else {
            Debug.Log("Item not added");
        }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem();
        if (receivedItem != null)
        {
            Debug.Log("Received item: " + receivedItem.name); // Puedes imprimir el nombre o cualquier propiedad que desees
        }
        else
        {
            Debug.Log("No item received");
        }
    }

    /* public void UseSelectedItem()
     {
         Item recivedItem = inventoryManager.GetSelectedItem(true);
         if (recivedItem != null){
             Debug.Log("Used item" + recivedItem);
         }
         else{
             Debug.Log("No item used");
         }
     }*/
}
