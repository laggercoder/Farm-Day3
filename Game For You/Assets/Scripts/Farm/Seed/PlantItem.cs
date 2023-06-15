using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlantItem : MonoBehaviour
{
    public PlantObject plant;
    [SerializeField] Button butonchose;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] FarmManager fm;
    public int count = 0;
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        butonchose.onClick.AddListener(chosePlant);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void chosePlant()
    {
        fm.SelectedPlantIntem(this);
    }
    public void InitializeUI()
    {
        icon.sprite = plant.iconPlant;
        name.text = plant.name;
    }
    public void AddCount()
    {
        Debug.Log("Test" + count);
        count = count + 1;
        Debug.Log("count : " + count);
    }
    public void PreCount()
    {
        if (count == 0) return;
        count = count - 1;
    }
    public void DeSpawnPlantItem()
    {
        if (count > 0) return;
        Destroy(transform.gameObject);
    }
}
