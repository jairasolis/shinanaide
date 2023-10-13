using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public Transform ObjectTransform; // Variable renamed from playerTransform to ObjectTransform
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
}
