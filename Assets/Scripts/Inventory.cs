using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> woods;
    private List<Item> metals;
    private List<Item> cloths;
    private List<Item> taps;

    private void Start()
    {
        woods = new List<Item>();
        metals = new List<Item>();
        cloths = new List<Item>();
        taps = new List<Item>();
    }

    private void Update()
    {
        
    }

    public void AddWood(Item item)
    {
        woods.Add(item);
    }

    public void AddMetal(Item item)
    {
        metals.Add(item);
    }

    public void AddCloth(Item item)
    {
        cloths.Add(item);
    }

    public void AddTap(Item item)
    {
        taps.Add(item);
    }

    public void PrintItems()
    {
        Debug.Log("Woods: " + woods.Count + " PCS");
        Debug.Log("Metals: " + metals.Count + " PCS");
        Debug.Log("Cloths: " + cloths.Count + " PCS");
        Debug.Log("Tapss: " + taps.Count + " PCS");
    }
}