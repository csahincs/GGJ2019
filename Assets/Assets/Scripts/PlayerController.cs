using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SmoothDamp Variables
    private float smoothTime = 0.5f;
    private float maxSpeed = 1f;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 speed = Vector3.zero;

    // Double Click Variables
    private float doubleClickTimeLimit = 0.25f;

    private Rigidbody rb;
    private bool climbing = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InputListener());
        currentPosition = transform.position;
        targetPosition = currentPosition;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (targetPosition == currentPosition)
        {
            if (climbing)
                rb.useGravity = false;
            return;
        }
        else
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref speed, smoothTime, maxSpeed);
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 objectPoint = hit.point;
                targetPosition = new Vector3(objectPoint.x, transform.position.y, transform.position.z);
                transform.LookAt(targetPosition);
            }
        }

    }
    private IEnumerator InputListener()
    {
        while (enabled)
        {
            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        maxSpeed = 1f;
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;
            yield return null; 
        }
    }

    private void DoubleClick()
    {
        maxSpeed = 2f;
    }

    void OnCollisionStay(Collision dataFromCollision)
    {
        if (dataFromCollision.gameObject.name != "Ladder")
        {
            return;
        }
        else
            if (Input.GetMouseButtonDown(1))
            {
                climbing = true;
                rb.useGravity = false;
                targetPosition = new Vector3(currentPosition.x, currentPosition.y + 3, currentPosition.z);
            }
    }
}

