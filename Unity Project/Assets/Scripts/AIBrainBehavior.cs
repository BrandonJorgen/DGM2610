using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBrainBehavior : MonoBehaviour
{
    public AIBaseSO aiBaseObj, idleBaseObj, chaseBaseObj, returnBaseObj, hoverBaseObj;
    public AITargetingBehavior aiTargeting;

    public float returnWaitTime = 3f;

    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    private WaitForSeconds returnWaitObj;
    private bool CanRun;
    private Vector3 spawnLoc;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = transform.position;
        returnWaitObj = new WaitForSeconds(returnWaitTime);
        StartCoroutine(Start());
    }

    //Hover around player before attacking
    //probably use stopping distance paired with a timer
    //how to make them back away from player once they attacked?
    private IEnumerator Start()
    {
        CanRun = true;
        while (CanRun)
        {
            aiBaseObj.BaseTask(agent);

            if (aiBaseObj == chaseBaseObj)
            {
                if (aiTargeting.possibleTargetList.Count == 0 && agent.remainingDistance <= 0.25f + 2.66f)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }

                if (agent.remainingDistance <= 4f)
                {
                    ChangeBase(hoverBaseObj);
                }
            }

            if (aiBaseObj == returnBaseObj)
            {
                if (agent.remainingDistance <= 0.25f)
                {
                    ChangeBase(idleBaseObj);
                }
            }
            
            yield return waitObj;
        }
    }

    public void ChangeBase(AIBaseSO obj)
    {
        aiBaseObj = obj;
    }
    
    public void ReturnToSpawn()
    {
        agent.destination = spawnLoc;
    }
}