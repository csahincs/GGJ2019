using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public Inventory userInventory;

    public GameObject tires;
    public GameObject vanCabin;
    public GameObject shower;
    public GameObject upperBed;
    public GameObject lowerBedWithCabinet;
    public GameObject cabinet;
    
    public List<int> tiresResources;
    public List<int> vanCabinResources;
    public List<int> showerResources;
    public List<int> upperBedResources;
    public List<int> lowerBedResources;
    public List<int> cabinetResources;
    
    public void Start()
    {
        tiresResources = new List<int>() { 0, 0, 0, 0, 4 };
        vanCabinResources = new List<int>() { 30, 10, 0, 0, 0 };
        showerResources = new List<int>() { 10, 0, 5, 0, 0 };
        upperBedResources = new List<int>() { 10, 0, 5, 0, 0 };
        lowerBedResources = new List<int>() { 20, 10, 5, 0, 0 };
        cabinetResources = new List<int>() { 20, 5, 0, 1, 0 };
    }

    public void CraftVanCabin()
    {
        if(!vanCabin.gameObject.activeInHierarchy) vanCabin.SetActive(Craft(userInventory, vanCabinResources));
    }

    public void CraftVanShower()
    {
        if (!shower.gameObject.activeInHierarchy) shower.SetActive(Craft(userInventory, showerResources));
    }

    public void CraftVanBedWithCabinet()
    {
        if (!lowerBedWithCabinet.gameObject.activeInHierarchy) lowerBedWithCabinet.SetActive(Craft(userInventory, upperBedResources));
    }

    public void CraftVanUpperBed()
    {
        if (!upperBed.gameObject.activeInHierarchy) upperBed.SetActive(Craft(userInventory, lowerBedResources));
    }

    public void CraftCabinet()
    {

        if (!cabinet.gameObject.activeInHierarchy) cabinet.SetActive(Craft(userInventory, cabinetResources));
    }

    public void CraftTires()
    {
        if (!tires.gameObject.activeInHierarchy) tires.SetActive(Craft(userInventory, tiresResources));
    }


    public bool Craft(Inventory playerInventory, List<int> needs)
    {
        if (playerInventory.WoodCount() >= needs[0] &&
           playerInventory.MetalCount() >= needs[1] &&
           playerInventory.ClothCount() >= needs[2] &&
           playerInventory.TapCount() >= needs[3] &&
           playerInventory.TireCount() >= needs[4])
        {
            playerInventory.RemoveDemandedNumberOfItems(needs[0], needs[1], needs[2], needs[3], needs[4]);
            playerInventory.Initialize();
            return true;
        }
        return false;
    }





}
