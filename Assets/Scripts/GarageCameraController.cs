using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCameraController : MonoBehaviour
{
    private Vector3 mouseClickStartPosition;
    private Vector3 mouseClickCurrentPosition;

    private Vector3 sphereCenter;
    private float sphereRadius = 10f;
    private float radiusDifferAmount = 0.1f;
    private float minSphereRadius = 5f;
    private float maxSphereRadius = 15f;

    private float gamma = -185f;
    private float theta = 85f;
    private float minTheta = 10f;
    private float maxTheta = 135f;

    public float cameraMovementSpeed = 1f;

    private bool isPlayerRotatingTheCamera = false;


    private void Start()
    {
        sphereCenter = new Vector3(0f, 2f, 0f);
    }

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickStartPosition = Input.mousePosition;
            isPlayerRotatingTheCamera = true;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseClickCurrentPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseClickStartPosition = Vector3.zero;
            mouseClickCurrentPosition = Vector3.zero;
            isPlayerRotatingTheCamera = false;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (sphereRadius - radiusDifferAmount >= minSphereRadius) sphereRadius -= radiusDifferAmount;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (sphereRadius + radiusDifferAmount <= maxSphereRadius) sphereRadius += radiusDifferAmount;
        }
    }

    private void FixedUpdate()
    {

        if (isPlayerRotatingTheCamera)
        {
            Vector3 mouseDirection = mouseClickCurrentPosition - mouseClickStartPosition;
            mouseDirection.Normalize();
            
            theta = Mathf.Clamp(theta - mouseDirection.y * cameraMovementSpeed, minTheta, maxTheta);
            gamma -= mouseDirection.x * cameraMovementSpeed;
        }

        Vector3 newPosition = sphereRadius * GetSphereIntersectionPoint();
        transform.LookAt(sphereCenter);
        transform.position = newPosition;
    }

    Vector3 GetSphereIntersectionPoint()
    {
        float degGamma = Mathf.Deg2Rad * gamma;
        float degTheta = Mathf.Deg2Rad * theta;

        float g = degGamma / 2 * Mathf.PI;
        float t = degTheta / 2 * Mathf.PI;

        g = degGamma - g;
        t = degTheta - t;

        return new Vector3(Mathf.Cos(g) * Mathf.Sin(t),
                           Mathf.Cos(t),
                           Mathf.Sin(g) * Mathf.Sin(t));
    }

}
