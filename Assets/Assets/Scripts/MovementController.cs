using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float smoothTime = 0.5f;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 speed = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        targetPosition = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (targetPosition == currentPosition + new Vector3(0.01f, 0.01f, 0.01f))
            return;
        else
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref speed, smoothTime);
    }

    void OnGUI()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log(objectHit.transform.position.x);
                targetPosition = new Vector3(objectHit.position.x, transform.position.y, transform.position.z);
            }
        }

    }
}
