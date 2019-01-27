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

    public GameObject bathCabin;
    public GameObject cabinet;
    public GameObject upperBed;
    public GameObject lowerBed;
    public GameObject tires;
    public GameObject cabin;


    public Sprite[] icons;

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
        bathCabinItem.Initialize(craftManager.showerResources, icons[0]);
        bathCabinBtn = bathCabinItem.GetComponent<Button>();

        CraftItem cabinetItem = Instantiate(craftItem) as CraftItem;
        cabinetItem.transform.SetParent(craftItemContent, false);
        cabinetItem.Initialize(craftManager.cabinetResources, icons[1]);
        cabinetBtn = cabinetItem.GetComponent<Button>();


        CraftItem upperBedItem = Instantiate(craftItem) as CraftItem;
        upperBedItem.transform.SetParent(craftItemContent, false);
        upperBedItem.Initialize(craftManager.upperBedResources, icons[2]);
        upperBedBtn = upperBedItem.GetComponent<Button>();


        CraftItem lowerBedItem = Instantiate(craftItem) as CraftItem;
        lowerBedItem.transform.SetParent(craftItemContent, false);
        lowerBedItem.Initialize(craftManager.lowerBedResources, icons[3]);
        lowerBedBtn = lowerBedItem.GetComponent<Button>();


        CraftItem tiresItem = Instantiate(craftItem) as CraftItem;
        tiresItem.transform.SetParent(craftItemContent, false);
        tiresItem.Initialize(craftManager.tiresResources, icons[4]);
        tiresBtn = tiresItem.GetComponent<Button>();


        CraftItem cabinItem = Instantiate(craftItem) as CraftItem;
        cabinItem.transform.SetParent(craftItemContent, false);
        cabinItem.Initialize(craftManager.vanCabinResources, icons[5]);
        cabinBtn = cabinItem.GetComponent<Button>();
    }
}
