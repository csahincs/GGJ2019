using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CraftItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button craftBtn;
    public Tooltip tooltip;

    public void Initialize(List<int> itemCounts) // [0] -> Wood, [1] -> Metal, [2] -> Cloth, [3] -> Tap, [4] -> Tire
    {
        craftBtn.onClick.RemoveAllListeners();
        craftBtn.onClick.AddListener(CraftBtnClicked);

        tooltip.Initialize(itemCounts);
    }


    public void CraftBtnClicked()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("asd");
        tooltip.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("132");
        tooltip.gameObject.SetActive(false);
    }
}
