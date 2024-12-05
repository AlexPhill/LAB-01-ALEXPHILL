using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class NavControl : MonoBehaviour
{
    public GameObject Target;
    NavMeshAgent agent;
    bool isWalking = true;
    Animator animator;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


      //  speed = Random.Range(0.5f, 2.0f);
     //   agent.speed = speed;
    //    animator.speed = agent.speed + 0.25f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isWalking)
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Boar")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
        if (other.name == "Heart")
        {
            isWalking = false;
            animator.SetTrigger("SPECIAL");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Boar")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
        if (other.name == "Heart")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
