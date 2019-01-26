using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offsetPosition = new Vector3(0, 5f, 0);
    private Vector3 initCamPos = new Vector3(1f, 4f, -11f);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initCamPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position;
        if (targetPosition.y > 1.5f)
        {
            transform.position = new Vector3(transform.position.x,
                Vector3.SmoothDamp(transform.position, offsetPosition, ref velocity, smoothTime).y,
                transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x,
                Vector3.SmoothDamp(transform.position, initCamPos, ref velocity, smoothTime).y,
                transform.position.z);
        }
    }
}
