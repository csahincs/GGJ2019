using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    private bool canFinish = false;
    private bool climbing = false;

    public bool isIdling = true;
    public bool isWalking = false;
    public bool isRuning = false;

    private float afterFloatX = 0.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private Inventory inventory;

    private Item collidingItem;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(InputListener());
        targetPosition = transform.position;

        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

        animator = gameObject.GetComponent<Animator>();
        inventory = gameObject.GetComponent<Inventory>();

        agent = GetComponent<NavMeshAgent>();
        agent.destination = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (agent.destination == transform.position)
            agent.speed = 0f;

        if (agent.speed > 1)
        {
            isRuning = true;
            isWalking = false;
            isIdling = false;
        }
        else if (agent.speed > 0)
        {
            isIdling = false;
            isWalking = true;
            isRuning = false;
        }
        else
        {
            isIdling = true;
            isWalking = false;
            isRuning = false;
        }

        animator.SetBool("isIdling", isIdling);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRuning", isRuning);
    }

    private void OnGUI()
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
        if (canClimb && Input.GetMouseButtonDown(1))
        {
            Debug.Log("asd");
            targetPosition = new Vector3(transform.position.x, transform.position.y + 3.2f, transform.position.z);
            climbing = true;
            Debug.Log(targetPosition);
        }

        if (Event.current.Equals(Event.KeyboardEvent("space")))
        {
            if (canFinish) {
                //finish game, teleport player to garage.
                SceneManager.LoadScene(2);
            }

            if (collidingItem != null)
            {
                switch (collidingItem.itemType)
                {
                    case ITEM_TYPES.WOOD:
                        inventory.AddWood(collidingItem);
                        break;
                    case ITEM_TYPES.METAL:
                        inventory.AddMetal(collidingItem);
                        break;
                    case ITEM_TYPES.CLOTH:
                        inventory.AddCloth(collidingItem);
                        break;
                    case ITEM_TYPES.TAP:
                        inventory.AddTap(collidingItem);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Destroy(collidingItem.gameObject);
                collidingItem = null;
                inventory.PrintItems();
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
        agent.speed = 1f;
        yield return new WaitForEndOfFrame();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            agent.speed = 1;
            agent.destination = hit.point;
        }


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
        agent.speed = 2f;
    }

    public void OnTriggerEnter(Collider dataFromCollider)
    {
        if (dataFromCollider.gameObject.name == "Ladder")
        {
            canClimb = true;
        }

        if (dataFromCollider.gameObject.tag == "Finish")
        {
            canFinish = true;
        }

        if (dataFromCollider.gameObject.tag == "Item")
        {
            collidingItem = dataFromCollider.gameObject.GetComponent<Item>();
            Debug.Log(collidingItem.itemType);
        }
        else
        {
            collidingItem = null;
        }
    }

    void OnTriggerExit(Collider dataFromCollider)
    {
        collidingItem = null;

        if (dataFromCollider.gameObject.name == "Ladder")
        {
            canClimb = false;
            Debug.Log("123");
        }

        if (dataFromCollider.gameObject.tag == "Finish")
        {
            canFinish = false;
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

