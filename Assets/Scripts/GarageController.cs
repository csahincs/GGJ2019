using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageController : MonoBehaviour
{
    public CraftManager craftManager;

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("q")))
        {
            craftManager.CraftVanCabin();
        }

        if (Event.current.Equals(Event.KeyboardEvent("w")))
        {
            craftManager.CraftCabinet();
        }

        if (Event.current.Equals(Event.KeyboardEvent("e")))
        {
            craftManager.CraftVanShower();
        }

        if (Event.current.Equals(Event.KeyboardEvent("r")))
        {
            craftManager.CraftVanBedWithCabinet();
        }

        if (Event.current.Equals(Event.KeyboardEvent("t")))
        {
            craftManager.CraftVanUpperBed();
        }

        if (Event.current.Equals(Event.KeyboardEvent("y")))
        {
            craftManager.CraftTires();
        }

        if (Event.current.Equals(Event.KeyboardEvent("f1")))
        {
            craftManager.Cheat();
        }
    }
}
