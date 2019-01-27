using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerInventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
