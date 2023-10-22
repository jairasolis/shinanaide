using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public float pushForce = 10f;
    public float pushRange = 2f;

    private bool isFollowingPuck = true;
    private bool gameInProgress = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameInProgress && isFollowingPuck)
        {
            GameObject puckObject = GameObject.FindGameObjectWithTag("Puck");

            if (puckObject != null)
            {
                float distanceToObject = Vector3.Distance(transform.position, puckObject.transform.position);

                if (distanceToObject <= pushRange)
                {
                    animator.SetBool("IsKicking", true);
                    UsePushForce(puckObject.transform);
                }
                else
                {
                    animator.SetBool("IsKicking", false);
                }

                agent.destination = puckObject.transform.position;
                animator.SetFloat("Speed", agent.velocity.magnitude);
            } 
        }
        else
        {
            agent.isStopped = true;
            animator.SetFloat("Speed", 0f);
        }
    }

    void UsePushForce(Transform puckTransform)
    {
        Rigidbody objectRigidbody = puckTransform.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            Vector3 pushDirection = (puckTransform.position - transform.position).normalized;
            float reducedPushForce = pushForce * 0.2f;
            objectRigidbody.AddForce(pushDirection * reducedPushForce, ForceMode.Impulse);
        }
    }

    public void SetShouldFollowPuck(bool shouldFollow)
    {
        isFollowingPuck = shouldFollow;
        animator.SetBool("IsKicking", false);
    }

    public void SetGameInProgress(bool inProgress)
    {
        gameInProgress = inProgress;
        agent.isStopped = false;
    }
}
