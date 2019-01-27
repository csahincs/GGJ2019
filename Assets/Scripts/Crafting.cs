using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crafting : MonoBehaviour
{
    public CraftItem craftItem;
    public Transform craftItemContent;

    public List<int> bathCabinResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> cabinetResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> upperBedResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> lowerBedResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> tiresResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> cabinResources = new List<int>() { 10, 10, 15, 10, 10 };

    public void Start()
    {
        Initialize();
    }


    public void Initialize()
    {
        CraftItem bathCabinItem = Instantiate(craftItem) as CraftItem;
        bathCabinItem.transform.SetParent(craftItemContent, false);
        bathCabinItem.Initialize(bathCabinResources);


        CraftItem cabinetItem = Instantiate(craftItem) as CraftItem;
        cabinetItem.transform.SetParent(craftItemContent, false);
        cabinetItem.Initialize(cabinetResources);


        CraftItem upperBedItem = Instantiate(craftItem) as CraftItem;
        upperBedItem.transform.SetParent(craftItemContent, false);
        upperBedItem.Initialize(upperBedResources);


        CraftItem lowerBedItem = Instantiate(craftItem) as CraftItem;
        lowerBedItem.transform.SetParent(craftItemContent, false);
        lowerBedItem.Initialize(lowerBedResources);


        CraftItem tiresItem = Instantiate(craftItem) as CraftItem;
        tiresItem.transform.SetParent(craftItemContent, false);
        tiresItem.Initialize(tiresResources);


        CraftItem cabinItem = Instantiate(craftItem) as CraftItem;
        cabinItem.transform.SetParent(craftItemContent, false);
        cabinItem.Initialize(cabinResources);
    }

    
}
