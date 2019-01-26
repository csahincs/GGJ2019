using UnityEngine;
using UnityEngine.EventSystems;

public class UIMapIconFunctions : MonoBehaviour, IPointerClickHandler
{
    GameObject map;
    private bool flag;

    private void Start()
    {
        map = GameObject.Find("UIMap");
        map.SetActive(false);
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (flag)
        {
            map.SetActive(false);
            flag = false;
        }
        else
        {
            map.SetActive(true);
            flag = true;
        }
    }
}