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
    public Item(ITEM_TYPES it)
    {
        itemType = it;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTiggerEnter(Collider col)
    {
        Debug.Log("AHAHAHAHA");
    }

    public ITEM_TYPES itemType;
}
