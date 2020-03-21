using System.Collections;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 spawnLoc;
    
    public AITargetingBehavior targetingBehavior;
    public float stunnedTimer = 1f, rotateSpeed = 1f;
    public UnityEvent endOfStunCountdown;

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
            var targetRotation = Quaternion.LookRotation(targetingBehavior.possibleTargetList[0].gameObj.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        if (targetingBehavior.possibleTargetList.Count != 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            //make the agent back away
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
        endOfStunCountdown.Invoke();
    }
}