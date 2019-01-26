using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tmp : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public bool isIdling = true;
    public bool isWalking = false;
    public bool isRuning = false;

    // Double Click Variables
    private float doubleClickTimeLimit = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.destination = transform.position;
        StartCoroutine(InputListener());
    }

    // Update is called once per frame
    void FixedUpdate()
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

    /*public void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                agent.speed = 1;
                agent.destination = hit.point;
            }
        }
    }*/


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
        Debug.Log("sa");
        agent.speed = 2f;
    }
}
