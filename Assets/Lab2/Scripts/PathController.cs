using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;

    public Animator animator;
    bool isWalking;
    List<Waypoint> thePath;
    Waypoint target;
    public int ActionNum = 0;
    public float MoveSpeed;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            //set starting point to the first waypoint
            target = thePath[0];
        }
        isWalking = false;
        animator.SetBool("isWalking", isWalking);
    }

    void rotateTowardsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void moveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            //overshoot target
            return;
        }
        //take step forward
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
            if (ActionNum >= 4)
            {
                ActionNum = 0;
                animator.SetInteger("ActionNum", ActionNum);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //switchtonexttarget
        target = pathManager.GetNextTarget();
        ActionNum++;
        animator.SetInteger("ActionNum", ActionNum);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "CollidedCheckpoint")
        {

            Debug.Log("Collison detected");
            isWalking = false;
            animator.SetBool("isWalking", isWalking);
        }
    }

    
}
