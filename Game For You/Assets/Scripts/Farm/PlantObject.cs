using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant",menuName ="Plant")]
public class PlantObject : ScriptableObject
{
    public SeedType plantName;
    public List<Sprite> plantStages;
    public float timeStages;
    public Sprite iconPlant;
    public Sprite inconMature;
    public float buyPrice;
    public float sellPrice;
    public int maxAllowed;

}
