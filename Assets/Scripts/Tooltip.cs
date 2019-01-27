using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI woodCountTxt;
    public TextMeshProUGUI metalCountTxt;
    public TextMeshProUGUI clothCountTxt;
    public TextMeshProUGUI tapCountTxt;
    public TextMeshProUGUI tireCountTxt;

    public void Initialize(List<int> itemsNeeded)
    {
        woodCountTxt.text = "Wood : " + itemsNeeded[0].ToString();
        metalCountTxt.text = "Metal : " + itemsNeeded[1].ToString();
        clothCountTxt.text = "Cloth : " + itemsNeeded[2].ToString();
        tapCountTxt.text = "Tap : " + itemsNeeded[3].ToString();
        tireCountTxt.text = "Tire : " + itemsNeeded[4].ToString();
    }
}
