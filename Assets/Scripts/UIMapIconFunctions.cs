using UnityEngine;
using UnityEngine.EventSystems;

public class UIMapIconFunctions : MonoBehaviour, IPointerClickHandler
{
    GameObject map;
    Animator mapAnimator;
    private bool turnOnOff;
    public float speedMult = 2.0f;

    private void Start()
    {
        map = GameObject.Find("UIMap");
        mapAnimator = map.GetComponent<Animator>();
        map.SetActive(false);
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (turnOnOff)
        {
            //map.SetActive(false);
            mapAnimator.SetFloat("speed", -speedMult);
            mapAnimator.Play("fadein");
            turnOnOff = false;
        }
        else
        {
            map.SetActive(true);
            mapAnimator.SetFloat("speed", speedMult);
            mapAnimator.Play("fadein");
            turnOnOff = true;
        }
    }
}