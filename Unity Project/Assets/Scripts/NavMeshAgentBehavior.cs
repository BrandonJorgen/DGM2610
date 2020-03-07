using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 spawnLoc;
    public bool stoppingBool;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = agent.transform.position;
    }

    public void SetDestination(Transform transformObj)
    {
        agent.destination = transformObj.position;
    }

    public void SetDestination(Vector3SO destinationObj)
    {
        var path = new NavMeshPath();
        
        agent.destination = destinationObj.vector3;

        if (agent.remainingDistance <= agent.stoppingDistance && agent.CalculatePath(transform.position, path))
        {
            //ReturnToSpawn();
        }
    }

    public void ReturnToSpawn()
    {
        agent.destination = spawnLoc;
    }

    public void StoppingDistanceChange()
    {
        if (stoppingBool)
        {
            agent.stoppingDistance = 2.66f;
        }
        else
        {
            agent.stoppingDistance = 0.25f;
        }
    }

    public void UpdateBool()
    {
        if (stoppingBool)
        {
            stoppingBool = false;
        }
        else
        {
            stoppingBool = true;
        }
    }
}