using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //SmoothDamp Variables
    private float smoothTime = 0.5f;
    private Vector3 targetPosition;
    private Vector3 speed = Vector3.zero;

    // Double Click Variables
    private float doubleClickTimeLimit = 0.25f;

    private Rigidbody rb;
    private Animator anim;
    private float maxSpeed = 1f;

    
    private bool canClimb = false;
    private bool climbing = false;
    private float afterFloatX = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InputListener());
        targetPosition = transform.position;

        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VectorEquality(targetPosition, transform.position))
        {
            if (climbing)
            {
                climbing = false;
                targetPosition = new Vector3(transform.position.x + afterFloatX, transform.position.y, transform.position.z);
            }
            return;
        }
        else
        {
            if (climbing)
                rb.useGravity = false;
            else
                rb.useGravity = true;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref speed, smoothTime, maxSpeed);

        }
    }

    void OnGUI()
    {
        if (!climbing && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 objectPoint = hit.point;
                targetPosition = new Vector3(objectPoint.x, transform.position.y, transform.position.z);
            }
        }
        if(canClimb && Input.GetMouseButtonDown(1))
        {
            Debug.Log("asd");
            targetPosition = new Vector3(transform.position.x, transform.position.y + 3.2f, transform.position.z);
            climbing = true;
            Debug.Log(targetPosition);
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

    void OnTriggerEnter(Collider dataFromCollider)
    {
        if (dataFromCollider.gameObject.name != "Ladder")
            return;
        else
        {
            canClimb = true;
            Debug.Log("asda");
        }
    }

    void OnTriggerExit(Collider dataFromCollider)
    {
        if (dataFromCollider.gameObject.name != "Ladder")
            return;
        else
        {
            canClimb = false;
            Debug.Log("123");
        }
    }

    private Vector3 AbsVector3(Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    private bool VectorEquality(Vector3 vector1, Vector3 vector2)
    {
        if ((Mathf.Abs(vector1.x) > Mathf.Abs(vector2.x) - 0.01f && (Mathf.Abs(vector1.x) < Mathf.Abs(vector2.x) + 0.01f)) && (Mathf.Abs(vector1.y) > Mathf.Abs(vector2.y) - 0.01f && (Mathf.Abs(vector1.y) < Mathf.Abs(vector2.y) + 0.01f)))
            return true;
        else
            return false;
    }
}

