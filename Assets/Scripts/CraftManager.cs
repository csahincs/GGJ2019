using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public Inventory userInventory;

    public CraftableItem tires;
    public CraftableItem vanCabin;
    public CraftableItem shower;
    public CraftableItem upperBed;
    public CraftableItem lowerBedWithCabinet;
    public CraftableItem cabinet;

    public void CraftVanCabin()
    {
        if(!vanCabin.gameObject.activeInHierarchy) vanCabin.gameObject.SetActive(vanCabin.Craft(userInventory));
    }

    public void CraftVanShower()
    {
        if (!shower.gameObject.activeInHierarchy) shower.gameObject.SetActive(shower.Craft(userInventory));
    }

    public void CraftVanBedWithCabinet()
    {
        if (!lowerBedWithCabinet.gameObject.activeInHierarchy) lowerBedWithCabinet.gameObject.SetActive(lowerBedWithCabinet.Craft(userInventory));
    }

    public void CraftVanUpperBed()
    {
        if (!upperBed.gameObject.activeInHierarchy) upperBed.gameObject.SetActive(upperBed.Craft(userInventory));
    }

    public void CraftCabinet()
    {
        if (!cabinet.gameObject.activeInHierarchy) cabinet.gameObject.SetActive(cabinet.Craft(userInventory));
    }

    public void CraftTires()
    {
        if (!tires.gameObject.activeInHierarchy) tires.gameObject.SetActive(tires.Craft(userInventory));
    }
    
}
