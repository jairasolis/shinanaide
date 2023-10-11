using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public Transform playerTransform;
    private NavMeshAgent agent;
    private Animator animator;
    public float pushForce = 10f;
    public float pushRange = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= pushRange)
        {

            animator.SetBool("IsKicking", true);
            UsePushForce();
        }
        else
        {
            animator.SetBool("IsKicking", false);
        }

        agent.destination = playerTransform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void UsePushForce()
    {
        Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            Vector3 pushDirection = (playerTransform.position - transform.position).normalized;
            float reducedPushForce = pushForce * 0.2f;
            playerRigidbody.AddForce(pushDirection * reducedPushForce, ForceMode.Impulse);
        }
    }
}