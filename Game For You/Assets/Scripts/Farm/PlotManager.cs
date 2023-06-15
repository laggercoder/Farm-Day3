using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private bool isPlanted;
    SpriteRenderer plant;
    BoxCollider2D plantColi;
    int planteStage = 0;
    PlantObject selectePlant;
    float timer;
    FarmManager farmManager;
    void Start()
    {
        farmManager = transform.parent.GetComponent<FarmManager>();
        plant = transform.GetChild(0).GetComponent< SpriteRenderer>();
        plantColi = transform.GetChild(0).GetComponent< BoxCollider2D>();
    }

    void Update()
    {
       if(isPlanted)
        {
            timer -=Time.deltaTime;
            if(timer < 0 && planteStage <selectePlant.plantStages.Count-1)
            {
                timer = selectePlant.timeStages;
                planteStage++;
                UpdateStages();
            }
        }
    }
    private void OnMouseDown()
    {
        if (isPlanted )
        {
            Harvest();
        }
        else if(farmManager.isPlaneting)
        {
            if (farmManager.selecPlant.count <= 0) return;
            Plant(farmManager.selecPlant.plant);
            farmManager.selecPlant.PreCount();
            farmManager.selecPlant.DeSpawnPlantItem();
        }

    }
    void Harvest()
    {
        if (planteStage != selectePlant.plantStages.Count-1) return;
        isPlanted = false;
        plantColi.enabled = false;
        plant.gameObject.SetActive(false);
        farmManager.isPlaneting = false;
        Debug.Log(selectePlant.name);
       // Inventory.inventory.AddItem(selectePlant);
        Inventory_UI.inventory.AddItemStored(selectePlant);
    }
    void Plant(PlantObject plantObject)
    {
        selectePlant = plantObject;
        isPlanted=true;
        planteStage = 0;
        UpdateStages();
        timer = selectePlant.timeStages;
        plantColi.enabled = true;
        plant.gameObject.SetActive(true);
    }
    void UpdateStages()
    {
       plant.sprite = selectePlant.plantStages[planteStage];
      //plantColi.size = plant.bounds.size;
      // plantColi.offset = new Vector2(0, plant.bounds.size.y);
    }
}
