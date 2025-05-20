using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyTest : MonoBehaviour
{
    public Transform target;
    private float distance;
    public float attackDistance;

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rb;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance < attackDistance)
        {
            agent.isStopped = true;
            animator.SetBool("isMoving", false);
        }
        else
        {
            agent.isStopped = false;
            agent.destination = target.position;
            animator.SetBool("isMoving", true);
        }
        
    }

    void OnAnimatorMove()
    {
        //agent.speed = animator.deltaPosition / Time.deltaTime;
    }
}
