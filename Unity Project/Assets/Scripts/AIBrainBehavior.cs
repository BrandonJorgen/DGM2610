using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBrainBehavior : MonoBehaviour
{
    public AIBaseSO aiBaseObj, idleBaseObj, chaseBaseObj, returnBaseObj, hoverBaseObj, attackBaseObj, backingBaseObj;
    public AITargetingBehavior aiTargeting;

    public IDName playerID, treasureID, aiID; //aiID is for the special attack stuff

    public float returnWaitTime = 3f, attackWaitTime = 1f, postAttackWaitTime = 1f, attackEventWaitTime = 1f;

    public UnityEvent attackEvent;

    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    private WaitForSeconds returnWaitObj, attackWaitObj, postAttackWaitObj, attackEventWaitObj;
    private bool canRun, canAttack = true; //placeholder for ending/restarting game thing
    private Vector3 spawnLoc, moveBackPosition, attackPosition;
    private NavMeshHit hit;
    private float attackCountdown;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(moveBackPosition, 1);
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = transform.position;
        returnWaitObj = new WaitForSeconds(returnWaitTime);
        attackWaitObj = new WaitForSeconds(attackWaitTime);
        postAttackWaitObj = new WaitForSeconds(postAttackWaitTime);
        attackEventWaitObj = new WaitForSeconds(attackEventWaitTime);
        attackCountdown = 2f;
        canAttack = true;
        StartCoroutine(Start());
    }
    
    //Unique special attack via IDName
    private IEnumerator Start()
    {
        canRun = true;
        while (canRun)
        {
            aiBaseObj.BaseTask(agent);
            
            if (aiBaseObj == chaseBaseObj)
            {
                if (aiTargeting.possibleTargetList.Count == 0)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }

                if (aiTargeting.possibleTargetList.Count != 0 && aiTargeting.possibleTargetList[0].nameIdObj == playerID)
                {
                    if (agent.remainingDistance <= 4f)
                    {
                        ResetAttackCountdown();
                        ChangeBase(hoverBaseObj);
                    }
                }

                if (aiTargeting.possibleTargetList.Count != 0 && aiTargeting.possibleTargetList[0].nameIdObj == treasureID)
                {
                    agent.stoppingDistance = 1f;
                    agent.radius += 0.25f;
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
                moveBackPosition = transform.position - transform.forward * (agent.stoppingDistance - agent.remainingDistance);
                NavMesh.SamplePosition(moveBackPosition, out hit, 2f, NavMesh.AllAreas);
                
                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    transform.LookAt(aiTargeting.possibleTargetList[0].gameObj.transform.position);
                    attackCountdown -= Time.deltaTime;
                    
                    if (attackCountdown <= 0 && aiTargeting.possibleTargetList.Count != 0 && canAttack)
                    {
                        attackPosition = aiTargeting.possibleTargetList[0].gameObj.transform.position;
                        transform.LookAt(attackPosition);
                        ChangeBase(attackBaseObj);
                        canAttack = false;
                        ResetAttackCountdown();
                        StartCoroutine(AttackCooldown());
                    }
                    
                    if (agent.remainingDistance > agent.stoppingDistance)
                    {
                        ChangeBase(chaseBaseObj);
                    }
                    
                    
                    if (agent.remainingDistance < agent.stoppingDistance - 1f)
                    {
                        agent.stoppingDistance = 0;
                        ChangeBase(backingBaseObj);
                    }
                }
                else
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }
                
                if (agent.remainingDistance > agent.stoppingDistance && aiTargeting.possibleTargetList.Count == 0)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }
            }

            if (aiBaseObj == backingBaseObj)
            {
                agent.destination = hit.position;
                
                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    transform.LookAt(aiTargeting.possibleTargetList[0].gameObj.transform.position);
                    attackCountdown -= Time.deltaTime;
                    
                    if (aiTargeting.possibleTargetList.Count != 0 && canAttack)
                    {
                        attackPosition = aiTargeting.possibleTargetList[0].gameObj.transform.position;
                        transform.LookAt(attackPosition);
                        ChangeBase(attackBaseObj);
                        canAttack = false;
                        ResetAttackCountdown();
                        StartCoroutine(AttackCooldown());
                    }
                    
                    if (agent.remainingDistance <= 0.25f || Vector3.Distance(transform.position, aiTargeting.possibleTargetList[0].gameObj.transform.position) >= 3f)
                    {
                        ResetAttackCountdown();
                        ChangeBase(hoverBaseObj);
                    }
                }

                if (aiTargeting.possibleTargetList.Count <= 0)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                }
            }

            if (aiBaseObj == attackBaseObj)
            {
                agent.destination = attackPosition;
                
                if (agent.remainingDistance <= agent.stoppingDistance + 0.25f)
                {
                    attackEvent.Invoke();
                    yield return postAttackWaitObj;
                    ChangeBase(hoverBaseObj);
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

    private void ResetAttackCountdown()
    {
        attackCountdown = 2f;
    }

    private IEnumerator AttackCooldown()
    {
        yield return attackWaitObj;
        canAttack = true;
    }
    //Special attack coroutine stuff here
}