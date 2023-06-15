using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] RectTransform rootTransform;
    [SerializeField] SlotManager slotManager;
    [SerializeField] RectTransform stored;
    [SerializeField] Button exit;
    [SerializeField] Button sell;
    [SerializeField] MoneyManager money;
    [SerializeField] TextMeshProUGUI moneyShow;
    public static Inventory_UI inventory;
     SlotManager selectedItem;
    private void Start()
    {
        inventory = this;
        exit.onClick.AddListener(closeStored);
        sell.onClick.AddListener(SellItem);
    }

    private void Update()
    {
        showStored();
    }
    private void showStored()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (stored.gameObject.activeSelf)
            {
                
                closeStored();
                
            }
            else
            {
                stored.gameObject.SetActive(true);
                ShowMoneyUI();
            }
        }
    }
    private void closeStored()
    {
        stored.gameObject.SetActive(false);
    }


    public void AddItemStored(PlantObject plantObject)
    {
        SlotManager item  = GetItemInventory(plantObject);
        if(int.Parse(item.count.text) >= plantObject.maxAllowed)  item = AddNewItem(plantObject);
        item.count.text = (int.Parse(item.count.text) + 1).ToString();
    }
    SlotManager GetItemInventory(PlantObject plantObject)
    {
        foreach( RectTransform slotitem in rootTransform)
        {
            SlotManager slot = slotitem.GetComponentInChildren<SlotManager>();
            if (slot.plantObject != plantObject) continue;
            if(int.Parse(slot.count.text)  >= plantObject.maxAllowed) continue;
            return slot;
        }
        return AddNewItem(plantObject);
    }
    SlotManager AddNewItem(PlantObject plantObject)
    {
        SlotManager slot = Instantiate(slotManager,rootTransform);
        slot.plantObject = plantObject;
        slot.count.text = "0";
        slot.image.sprite = plantObject.inconMature;
        return slot;
    }
    /*public void AddItem(PlantObject plantObject)
   {
       ItemInventory itemInventory = getItem(plantObject);
       if (itemInventory.count >= plantObject.maxAllowed) itemInventory = AddEmtyItem(plantObject);
       itemInventory.count++;
   }
   ItemInventory getItem(PlantObject plantObject)
   {
       foreach (var item in items)
       {
           if (item.plantObject != plantObject) continue;
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
   }

   void LoadUI()
   {
      foreach(var item in items)
       {
           SlotManager newSlot = Instantiate(slotManager, rootTransform);
           newSlot.count.text = item.count.ToString();
           newSlot.image.sprite = item.plantObject.inconMature;
       } 
   }
   void ReloadUI()
   {
       foreach(RectTransform item in rootTransform)
       {
           Destroy(item.gameObject);
       }
   }



   private void OnEnable()
   {
       LoadUI();
       ReloadUI();
   }*/


    void SellItem()
    {
        if(selectedItem == null) return;    
        if (int.Parse(selectedItem.count.text) == 1)
        {
            Destroy(selectedItem.gameObject);
            return;
        }
        selectedItem.count.text = (int.Parse(selectedItem.count.text) - 1).ToString();
        float moneyAdd = selectedItem.plantObject.sellPrice ;
        SetMoneyUI(moneyAdd);
    }
    void SetMoneyUI(float moneychange)
    { 
        moneyShow.text = "$" + money.AddMoney(moneychange).ToString();
    }
    /*void SellOneItem()
    {
        
        //SlotManager slot = GetItemSell();
        if (int.Parse(slot.count.text) == 1)
        {
            Destroy(slot.gameObject);
            return;
        }
        slot.count.text = (int.Parse(slot.count.text) -1).ToString();
        Debug.Log(slot.plantObject.sellPrice * int.Parse(slot.count.text));
    }
    void SellItems(int countSell)
    {

       // SlotManager slot = GetItemSell();
        if (int.Parse(slot.count.text) - countSell < 0) return;
        slot.count.text = (int.Parse(slot.count.text) - countSell).ToString();
        Debug.Log(slot.plantObject.sellPrice * int.Parse(slot.count.text));
        
    }*/
    public void  GetItemSell(SlotManager newSlotChose)
    {
        if(newSlotChose == selectedItem)
        {
            if (selectedItem == null) return;
            selectedItem.imageChose.color = Color.white;

        }
        else
        {
            if (selectedItem != null) selectedItem.imageChose.color = Color.white; 
            selectedItem = newSlotChose;
            selectedItem.imageChose.color = Color.blue;
        }
    }
    private void ShowMoneyUI()
    {
        moneyShow.text  = money.money.ToString();
    }



}
