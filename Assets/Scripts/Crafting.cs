using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crafting : MonoBehaviour
{
    private Button bathCabinBtn;
    private Button cabinetBtn;
    private Button upperBedBtn;
    private Button lowerBedBtn;
    private Button tiresBtn;
    private Button cabinBtn;


    public CraftItem craftItem;
    public Transform craftItemContent;
    public CraftManager craftManager;
    


    public List<int> bathCabinResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> cabinetResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> upperBedResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> lowerBedResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> tiresResources = new List<int>() { 10, 10, 15, 10, 10 };
    public List<int> cabinResources = new List<int>() { 10, 10, 15, 10, 10 };

    public void Start()
    {
        Initialize();

        bathCabinBtn.onClick.RemoveAllListeners();
        bathCabinBtn.onClick.AddListener(craftManager.CraftVanShower);


        cabinetBtn.onClick.RemoveAllListeners();
        cabinetBtn.onClick.AddListener(craftManager.CraftCabinet);


        upperBedBtn.onClick.RemoveAllListeners();
        upperBedBtn.onClick.AddListener(craftManager.CraftVanUpperBed);


        lowerBedBtn.onClick.RemoveAllListeners();
        lowerBedBtn.onClick.AddListener(craftManager.CraftVanBedWithCabinet);


        tiresBtn.onClick.RemoveAllListeners();
        tiresBtn.onClick.AddListener(craftManager.CraftTires);


        cabinBtn.onClick.RemoveAllListeners();
        cabinBtn.onClick.AddListener(craftManager.CraftVanCabin);
    }


    public void Initialize()
    {
        CraftItem bathCabinItem = Instantiate(craftItem) as CraftItem;
        bathCabinItem.transform.SetParent(craftItemContent, false);
        bathCabinItem.Initialize(bathCabinResources);
        bathCabinBtn = bathCabinItem.GetComponent<Button>();

        CraftItem cabinetItem = Instantiate(craftItem) as CraftItem;
        cabinetItem.transform.SetParent(craftItemContent, false);
        cabinetItem.Initialize(cabinetResources);
        cabinetBtn = cabinetItem.GetComponent<Button>();


        CraftItem upperBedItem = Instantiate(craftItem) as CraftItem;
        upperBedItem.transform.SetParent(craftItemContent, false);
        upperBedItem.Initialize(upperBedResources);
        upperBedBtn = upperBedItem.GetComponent<Button>();


        CraftItem lowerBedItem = Instantiate(craftItem) as CraftItem;
        lowerBedItem.transform.SetParent(craftItemContent, false);
        lowerBedItem.Initialize(lowerBedResources);
        lowerBedBtn = lowerBedItem.GetComponent<Button>();


        CraftItem tiresItem = Instantiate(craftItem) as CraftItem;
        tiresItem.transform.SetParent(craftItemContent, false);
        tiresItem.Initialize(tiresResources);
        tiresBtn = tiresItem.GetComponent<Button>();


        CraftItem cabinItem = Instantiate(craftItem) as CraftItem;
        cabinItem.transform.SetParent(craftItemContent, false);
        cabinItem.Initialize(cabinResources);
        cabinBtn = cabinItem.GetComponent<Button>();
    }

    
}
