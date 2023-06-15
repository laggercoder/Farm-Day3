using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public PlantItem selecPlant;
    public bool isPlaneting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectedPlantIntem(PlantItem newPlant)
    {
        if(selecPlant == newPlant)
        {
            Debug.Log("DeSelected " + selecPlant.plant.plantName);
            selecPlant = null;
            isPlaneting = false;

        }
        else
        {
            selecPlant = newPlant; 
            Debug.Log("Selected " + selecPlant.plant.plantName);
            isPlaneting = true;
        }

    }
}
