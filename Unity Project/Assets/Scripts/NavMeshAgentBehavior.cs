using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    public UnityEvent reachedDestination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
    }

    public void SetDestination(Vector3SO destination)
    {
        agent.destination = destination.vector3;
    }

    public void SetDestination(Transform transformObj)
    {
        NavMeshPath path = new NavMeshPath();
        
        agent.destination = transformObj.position;

        if (agent.remainingDistance <= 0.25 && agent.CalculatePath(transform.position, path))
        {
            reachedDestination.Invoke();
        }
    }
}
