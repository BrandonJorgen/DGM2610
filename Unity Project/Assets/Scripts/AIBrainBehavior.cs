using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBrainBehavior : MonoBehaviour
{
    public AIBaseSO aiBaseObj, idleBaseObj, chaseBaseObj, returnBaseObj, hoverBaseObj, attackBaseObj;
    public AITargetingBehavior aiTargeting;

    public IDName playerID, aiID; //aiID is for the special attack stuff

    public float returnWaitTime = 3f, jumpBackWaitTime = 1f, attackWaitTime = 1f;

    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    private WaitForSeconds returnWaitObj, jumpBackWaitObj, attackWaitObj;
    private bool CanRun; //placeholder for ending/restarting game thing
    private Vector3 spawnLoc;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = transform.position;
        returnWaitObj = new WaitForSeconds(returnWaitTime);
        jumpBackWaitObj = new WaitForSeconds(jumpBackWaitTime);
        attackWaitObj = new WaitForSeconds(attackWaitTime);
        StartCoroutine(Start());
    }

    //Hover around player before attacking
    //probably use stopping distance paired with a timer
    //how to make them back away from player once they attacked?
    //In hover, make the enemy look at the target
    //Unique special attack via IDName
    private IEnumerator Start()
    {
        CanRun = true;
        while (CanRun)
        {
            aiBaseObj.BaseTask(agent);

            if (aiBaseObj == chaseBaseObj)
            {
                if (aiTargeting.possibleTargetList.Count == 0 && agent.remainingDistance <= 0.25f + agent.stoppingDistance)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }

                if (aiTargeting.possibleTargetList.Count != 0 && aiTargeting.possibleTargetList[0].nameIdObj == playerID)
                {
                    if (agent.remainingDistance <= 3f)
                    {
                        ChangeBase(hoverBaseObj);
                    }
                }
            }

            if (aiBaseObj == returnBaseObj)
            {
                if (agent.remainingDistance <= 0.25f)
                {
                    ChangeBase(idleBaseObj);
                }
            }

            if (aiBaseObj == hoverBaseObj)
            {
                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    if (agent.remainingDistance > 3f)
                    {
                        ChangeBase(chaseBaseObj);
                    }
                    
                    if (agent.remainingDistance <= 3f)
                    {
                        yield return attackWaitObj;
                        //Animation stuff, maybe some cool material changing thing?
                        //stop looking at player as to not completely merc them, allowing them to dodge
                        ChangeBase(attackBaseObj);
                        yield return attackWaitObj;
                        ChangeBase(hoverBaseObj);
                    }
                }
                
                if (agent.remainingDistance > 3f && aiTargeting.possibleTargetList.Count == 0)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }
            }

            if (aiBaseObj == attackBaseObj)
            {
                if (agent.remainingDistance < 3f)
                {
                    StartCoroutine(JumpBackTimer());
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

    public void JumpBack()
    {
        transform.Translate(0, 0, -2f);
    }

    private IEnumerator JumpBackTimer()
    {
        yield return jumpBackWaitObj;
        if (agent.remainingDistance < 3f)
        {
            JumpBack();
        }
    }
    
    //Special attack coroutine stuff here
}