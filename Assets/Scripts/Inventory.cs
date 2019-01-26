﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> woods;
    private List<Item> metals;
    private List<Item> cloths;
    private List<Item> taps;
    private List<Item> tires;

    private void Start()
    {
        woods = new List<Item>();
        metals = new List<Item>();
        cloths = new List<Item>();
        taps = new List<Item>();
        tires = new List<Item>();

        SetTestItems();
    }

    void SetTestItems()
    {
        for (int itemIndex = 0; itemIndex < 500; itemIndex++)
        {
            woods.Add(new Item(ITEM_TYPES.WOOD));
            metals.Add(new Item(ITEM_TYPES.METAL));
            cloths.Add(new Item(ITEM_TYPES.CLOTH));
            taps.Add(new Item(ITEM_TYPES.TAP));
            tires.Add(new Item(ITEM_TYPES.TIRE));
        }
    }

    public void AddWood(Item item)
    {
        woods.Add(item);
    }

    public int WoodCount()
    {
        return woods.Count;
    }

    public void AddMetal(Item item)
    {
        metals.Add(item);
    }

    public int MetalCount()
    {
        return metals.Count;
    }

    public void AddCloth(Item item)
    {
        cloths.Add(item);
    }

    public int ClothCount()
    {
        return cloths.Count;
    }

    public void AddTap(Item item)
    {
        taps.Add(item);
    }

    public int TapCount()
    {
        return taps.Count;
    }

    public void AddTire(Item item)
    {
        tires.Add(item);
    }

    public int TireCount()
    {
        return tires.Count;
    }

    public void RemoveDemandedNumberOfItems(int woodCount, int metalCount, int clothCount, int tapCount, int tireCount)
    {
        woods.RemoveRange(0, woodCount);
        metals.RemoveRange(0, metalCount);
        cloths.RemoveRange(0, clothCount);
        taps.RemoveRange(0, tapCount);
        tires.RemoveRange(0, tireCount);
    }

    public void PrintItems()
    {
        Debug.Log("Woods: " + woods.Count + " PCS");
        Debug.Log("Metals: " + metals.Count + " PCS");
        Debug.Log("Cloths: " + cloths.Count + " PCS");
        Debug.Log("Taps: " + taps.Count + " PCS");
        Debug.Log("Tires: " + tires.Count + " PCS");
    }
}