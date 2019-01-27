using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> woods;
    private List<Item> metals;
    private List<Item> cloths;
    private List<Item> taps;
    private List<Item> tires;

    public Sprite[] iconImages;
    public InventoryItemStack itemStack;
    public Transform itemContent;

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
            Item wood = new Item();
            wood.itemType = ITEM_TYPES.WOOD;
            woods.Add(wood);

            Item metal = new Item();
            metal.itemType = ITEM_TYPES.METAL;
            metals.Add(metal);

            Item cloth = new Item();
            cloth.itemType = ITEM_TYPES.CLOTH;
            cloths.Add(cloth);

            Item tap = new Item();
            tap.itemType = ITEM_TYPES.TAP;
            taps.Add(tap);

            Item tire = new Item();
            tire.itemType = ITEM_TYPES.TIRE;
            tires.Add(tire);
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

    public void Initialize()
    {
        int woodCount = woods.Count / 10;
        int metalCount = metals.Count / 10;
        int clothCount = cloths.Count / 10;
        int tapCount = taps.Count / 10;

        for (int i = 0; i < woodCount; i++)
        {
            InventoryItemStack woodItem = Instantiate(itemStack) as InventoryItemStack;
            woodItem.gameObject.transform.SetParent(itemContent, false);
            woodItem.Initialize(iconImages[0], 10);
        }
        InventoryItemStack lastWoodItem = Instantiate(itemStack) as InventoryItemStack;
        lastWoodItem.gameObject.transform.SetParent(itemContent, false);
        lastWoodItem.Initialize(iconImages[0], woods.Count - (woodCount * 10));


        for (int i = 0; i < woodCount; i++)
        {
            InventoryItemStack metalItem = Instantiate(itemStack) as InventoryItemStack;
            metalItem.gameObject.transform.SetParent(itemContent, false);
            metalItem.Initialize(iconImages[1], 10);
        }
        InventoryItemStack lastMetalItem = Instantiate(itemStack) as InventoryItemStack;
        lastMetalItem.gameObject.transform.SetParent(itemContent, false);
        lastMetalItem.Initialize(iconImages[1], metals.Count - (metalCount * 10));

        for (int i = 0; i < woodCount; i++)
        {
            InventoryItemStack clothItem = Instantiate(itemStack) as InventoryItemStack;
            clothItem.gameObject.transform.SetParent(itemContent, false);
            clothItem.Initialize(iconImages[2], 10);
        }
        InventoryItemStack lastClothItem = Instantiate(itemStack) as InventoryItemStack;
        lastClothItem.gameObject.transform.SetParent(itemContent, false);
        lastClothItem.Initialize(iconImages[2], cloths.Count - (clothCount * 10));

        for (int i = 0; i < woodCount; i++)
        {
            InventoryItemStack tapItem = Instantiate(itemStack) as InventoryItemStack;
            tapItem.gameObject.transform.SetParent(itemContent, false);
            tapItem.Initialize(iconImages[3], 10);
        }
        InventoryItemStack lastTapItem = Instantiate(itemStack) as InventoryItemStack;
        lastTapItem.gameObject.transform.SetParent(itemContent, false);
        lastTapItem.Initialize(iconImages[3], taps.Count - (tapCount * 10));
    }
}