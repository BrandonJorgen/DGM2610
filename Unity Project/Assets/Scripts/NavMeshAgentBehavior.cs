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
    private bool hadTarget;
    
    public AITargetingBehavior targetingBehavior;
    public float stunnedTimer = 1f, returnTimer = 1f, rotateSpeed = 1f;
    public UnityEvent endOfStunCountdown;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = transform.position;
    }

    private void Update()
    {
        SetDestination();
        if (hadTarget && targetingBehavior.possibleTargetList.Count == 0)
        {
            LostSight();
        }
    }

    public void SetDestination()
    {
        if (targetingBehavior.possibleTargetList.Count != 0)
        {
            hadTarget = true;
            agent.destination = targetingBehavior.possibleTargetList[0].gameObj.transform.position;
            var targetRotation = Quaternion.LookRotation(targetingBehavior.possibleTargetList[0].gameObj.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        if (targetingBehavior.possibleTargetList.Count != 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            //make the agent back away
        }
    }

    public void LostSight()
    {
        if (agent.remainingDistance <= 0.25f + agent.stoppingDistance)
        {
            hadTarget = false;
            StartCoroutine(ReturnToSpawnCountdown());
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

    private IEnumerator ReturnToSpawnCountdown()
    {
        Debug.Log("return to spawn countdown started");
        yield return new WaitForSeconds(returnTimer);
        ReturnToSpawn();
    }
}