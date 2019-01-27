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
    public string animationName;
    private Animator itemAnimator;

    // Start is called before the first frame update
    void Start()
    {
        itemAnimator = GetComponent<Animator>();
        itemAnimator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemAnimator.enabled = true;
            itemAnimator.Play(animationName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Jump"))
        {
            Destroy(gameObject);//TODO do inventory related things here.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemAnimator.enabled = false;
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
