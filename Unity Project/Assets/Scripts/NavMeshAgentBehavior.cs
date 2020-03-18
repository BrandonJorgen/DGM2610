using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 spawnLoc;
    
    public AITargetingBehavior targetingBehavior;
    public float stunnedTimer = 1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = agent.transform.position;
    }

    public void SetDestination()
    {
        if (targetingBehavior.possibleTargetList.Count != 0)
        {
            agent.destination = targetingBehavior.possibleTargetList[0].gameObj.transform.position;
        }
    }

    public void ReturnToSpawn()
    {
        agent.destination = spawnLoc;
    }

    public void AgentStunned()
    {
        agent.destination = transform.position;
        StartCoroutine(StunnedCountdown());
    }

    private IEnumerator StunnedCountdown()
    {
        yield return new WaitForSeconds(stunnedTimer);
        SetDestination();
    }
}