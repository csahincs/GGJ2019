using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public enum ITEM_TYPES
{
    WOOD = 0,
    METAL,
    CLOTH,
    TAP,
    TIRE
};

public class Item : MonoBehaviour
{
    public ITEM_TYPES itemType;
}
