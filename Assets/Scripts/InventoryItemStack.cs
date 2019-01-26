using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryItemStack : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemCountTxt;
    public void Initialize(Sprite itemIcon, int count)
    {
            this.icon.sprite = itemIcon;
            itemCountTxt.text = count.ToString();
    }
}
