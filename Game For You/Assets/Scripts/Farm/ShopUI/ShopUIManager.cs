using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RectTransform rootItems;
    [SerializeField] Button buyItem;
    [SerializeField] TextMeshProUGUI moneyShow;
    [SerializeField] Button exit;
    ItemMangager selectedItem;
    private void Start()
    {
        buyItem.onClick.AddListener(BuyItem);
        exit.onClick.AddListener(CloseShop);
    }
    private void Update()
    {
        ShowShop();
    }

    public void BuyItem()
    {
        if (selectedItem.plantObj.buyPrice > moneyManager.money) return;
        SetMoneyManager(selectedItem.plantObj.buyPrice);
        Debug.Log( "Buy item " +selectedItem.plantObj.name);
        SeedManager.instance.AddPlantItem(selectedItem.plantObj);
    }
    public ItemMangager GetItemActive( ItemMangager newItem)
    {
        if(selectedItem == newItem)
        {
            selectedItem.active = false;
            selectedItem.RemoveActive();
        }
        else
        {
            if(selectedItem!=null) selectedItem.RemoveActive();
            selectedItem = newItem;
            selectedItem.active = true;
            selectedItem.setItemActive();
        }
        return selectedItem;
    }
    private void SetMoneyManager(float money)
    {
        moneyShow.text = moneyManager.PreviousMoney(money).ToString();
    }
    private void CloseShop()
    {
        rootItems.gameObject.SetActive(false);
    }
    private void ShowShop()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if(rootItems.gameObject.activeSelf)
            {
                rootItems.gameObject.SetActive(false);
            }
            else
            {
                rootItems.gameObject.SetActive(true);
                ShowMoneyUI();
            }
        }
    }
    private void ShowMoneyUI()
    {
        moneyShow.text = moneyManager.money.ToString();
    }

}
