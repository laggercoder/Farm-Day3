using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    [SerializeField] PlantItem plantItem;
    [SerializeField] RectTransform rootTranform;
    public static SeedManager instance;

    private void Start()
    {
        instance = this;
    }
    public void AddPlantItem(PlantObject plantObject)
    {
       PlantItem item = GetPlantItem(plantObject);
       Debug.Log(item.plant.name);
       item.AddCount();
    }
    PlantItem GetPlantItem(PlantObject plantObject)
    {
        foreach(Transform item in transform)
        {
            PlantItem plantItem = item.GetComponent<PlantItem>();
            if (plantItem.plant != plantObject) continue;
            return plantItem;
        }
        return AddNewPlantItem(plantObject);
    }
    PlantItem AddNewPlantItem(PlantObject plantObject)
    {
        PlantItem newPlantItem = Instantiate(plantItem, rootTranform);
        newPlantItem.plant = plantObject;
        newPlantItem.count = 0;
        newPlantItem.InitializeUI();
        return newPlantItem;  
    }
}
