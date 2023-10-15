using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform ObjectTransform;
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
            float distanceToObject = Vector3.Distance(transform.position, ObjectTransform.position);

            if (distanceToObject <= pushRange)
            {
                animator.SetBool("IsKicking", true);
                UsePushForce();
            }
            else
            {
                animator.SetBool("IsKicking", false);
            }

            agent.destination = ObjectTransform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            agent.isStopped = true;
            animator.SetFloat("Speed", 0f);
        }
    }

    void UsePushForce()
    {
        Rigidbody objectRigidbody = ObjectTransform.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            Vector3 pushDirection = (ObjectTransform.position - transform.position).normalized;
            float reducedPushForce = pushForce * 0.2f;
            objectRigidbody.AddForce(pushDirection * reducedPushForce, ForceMode.Impulse);
        }
    }

    public void SetShouldFollowPuck(bool shouldFollow)
    {
        isFollowingPuck = shouldFollow;
        animator.SetBool("IsKicking", false);
        animator.SetFloat(ScoreParameter, score);

    }

    public void SetGameInProgress(bool inProgress)
    {
        gameInProgress = inProgress;
        agent.isStopped = false;
    }
}
