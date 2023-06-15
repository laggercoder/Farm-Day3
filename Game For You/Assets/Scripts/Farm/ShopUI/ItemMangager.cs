using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemMangager : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private Button choseItem;
    [SerializeField] private ShopUIManager shopUIManager;
    public bool active;
    public PlantObject plantObj;

    private void Start()
    {
        choseItem = gameObject.GetComponent<Button>();
        choseItem.onClick.AddListener(ChoseItem);
        setUIItem();
    }
    void ChoseItem()
    {
        shopUIManager.GetItemActive(this);
        setInfoItem();
    }
    void setUIItem()
    {
        transform.gameObject.name = plantObj.name;
        icon.sprite = plantObj.iconPlant;   
    }
    void setInfoItem()
    {
        name.text = plantObj.name;
        price.text = "$" + plantObj.buyPrice.ToString();
    }
    public void setItemActive()
    {
        Debug.Log("Active" + transform.name);
    }
    public void RemoveActive()
    {
        Debug.Log("DeActive" + transform.name);
    }
}
