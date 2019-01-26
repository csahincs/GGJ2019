using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftableItem : MonoBehaviour
{
    public int woodNeed;
    public int metalNeed;
    public int clothNeed;
    public int tapNeed;
    public int tireNeed;

    public bool Craft(Inventory playerInventory)
    {
        if(playerInventory.WoodCount() >= woodNeed &&
           playerInventory.MetalCount() >= metalNeed &&
           playerInventory.ClothCount() >= clothNeed &&
           playerInventory.TapCount() >= tapNeed &&
           playerInventory.TireCount() >= tireNeed)
        {
            playerInventory.RemoveDemandedNumberOfItems(woodNeed, metalNeed, clothNeed, tapNeed, tireNeed);
            return true;
        }

        return false;
    }
}
