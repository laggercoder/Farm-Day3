using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /*public List<ItemInventory> items;
    public static Inventory inventory;

    private void Start()
    {
        inventory = this;
    }
    public void AddItem(PlantObject plantObject)
    {
        ItemInventory itemInventory = getItem(plantObject);
        if (itemInventory.count >= plantObject.maxAllowed) itemInventory = AddEmtyItem(plantObject);
        itemInventory.count++;
    }
    ItemInventory getItem(PlantObject plantObject)
    {
        foreach(var item in items)
        { 
            if(item.plantObject != plantObject)  continue;
            if (plantObject.maxAllowed == item.count) continue;
            return item;
        }
        return AddEmtyItem(plantObject);
    }
    ItemInventory AddEmtyItem(PlantObject plantObject)
    {
        ItemInventory itemInventory = new ItemInventory
        {

            plantObject = plantObject,
            count = 0
        };
        items.Add(itemInventory);
        return itemInventory;
    }*/
}
