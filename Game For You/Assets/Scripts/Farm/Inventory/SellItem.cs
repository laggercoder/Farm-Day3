using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItem : MonoBehaviour
{
    public SlotManager selectedItem;
    /*void SellItem()
    {
        foreach (RectTransform slotitem in rootTransform)
        {
            SlotManager slot = slotitem.GetComponentInChildren<SlotManager>();
            if (!slot.active) continue;
            Destroy(slotitem.gameObject);
            Debug.Log(slot.plantObject.sellPrice * int.Parse(slot.count.text));
        }
    }
    void SellOneItem()
    {
        foreach (RectTransform slotitem in rootTransform)
        {
            SlotManager slot = slotitem.GetComponentInChildren<SlotManager>();
            if (!slot.active) continue;
            slot.count.text = (int.Parse(slot.count.text) - 1).ToString();
            Debug.Log(slot.plantObject.sellPrice * int.Parse(slot.count.text));
        }
    }
    void SellItems(int countSell)
    {
        foreach (RectTransform slotitem in rootTransform)
        {
            SlotManager slot = slotitem.GetComponentInChildren<SlotManager>();
            if (!slot.active) continue;
            if (int.Parse(slot.count.text) - countSell < 0) return;
            slot.count.text = (int.Parse(slot.count.text) - countSell).ToString();
            Debug.Log(slot.plantObject.sellPrice * int.Parse(slot.count.text));
        }
    }
    SlotManager GetItemSell(SlotManager slotActive)
    {

    }*/
}
