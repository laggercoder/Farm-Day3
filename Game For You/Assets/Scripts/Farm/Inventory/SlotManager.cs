using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
public class SlotManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public TextMeshProUGUI count;
    public PlantObject plantObject;
    public bool active =false;
    [SerializeField] private Button chose;
    public Image imageChose;
    private void Start()
    {
        chose.onClick.AddListener(ChoseItem);
    }
    void ChoseItem()
    {
        Inventory_UI.inventory.GetItemSell(this);
    }
}
