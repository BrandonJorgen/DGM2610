using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBrainBehavior : MonoBehaviour
{
    public AIBaseSO aiBaseObj, idleBaseObj, chaseBaseObj, returnBaseObj, hoverBaseObj, attackBaseObj, backingBaseObj;
    public AITargetingBehavior aiTargeting;
    public SphereCollider aiSightRadius;

    public IDName playerID, treasureID, aiID; //aiID is for the special attack stuff

    public float returnWaitTime = 3f, attackWaitTime = 1f, postAttackWaitTime = 1f, attackEventWaitTime = 1f;

    public UnityEvent attackEvent, preAttackEvent;

    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    private WaitForSeconds returnWaitObj, attackWaitObj, postAttackWaitObj, attackEventWaitObj;
    private bool canRun, canAttack = true, attacked;
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
        attacked = false;
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
                if (agent.remainingDistance > agent.stoppingDistance && aiTargeting.possibleTargetList.Count == 0)
                {
                    ChangeBase(returnBaseObj);
                    yield return returnWaitObj;
                    ReturnToSpawn();
                    ResetAttackCountdown();
                }

                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    if (aiTargeting.possibleTargetList[0].nameIdObj == playerID)
                    {
                        if (agent.remainingDistance <= aiSightRadius.radius / 2)
                        {
                            ResetAttackCountdown();
                            ChangeBase(hoverBaseObj);
                        }
                    }

                    if (aiTargeting.possibleTargetList[0].nameIdObj == treasureID)
                    {
                        if (aiTargeting.possibleTargetList.Count != 0)
                        {
                            agent.stoppingDistance = 1f;
                            agent.radius += 0.25f;
                        }
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
                if (agent.remainingDistance < aiSightRadius.radius / 2 + 0.75f)
                {
                    moveBackPosition = transform.position - transform.forward * (agent.stoppingDistance - agent.remainingDistance);
                    NavMesh.SamplePosition(moveBackPosition, out hit, 2f, NavMesh.AllAreas);
                }
                
                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    transform.LookAt(aiTargeting.possibleTargetList[0].gameObj.transform.position);
                    attackCountdown -= Time.deltaTime;
                    
                    if (attackCountdown <= 0 && canAttack)
                    {
                        ChangeBase(attackBaseObj);
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
                    
                    if (attackCountdown <= 0 && canAttack)
                    {
                        ChangeBase(attackBaseObj);
                    } 
                    else if (agent.remainingDistance <= 0.25f)
                    {
                        ChangeBase(hoverBaseObj);
                    }
                }
                else
                {
                    ChangeBase(hoverBaseObj);
                }
            }
            
            if (aiBaseObj == attackBaseObj)
            {
                if (aiTargeting.possibleTargetList.Count != 0)
                {
                    if (!attacked)
                    {
                        transform.LookAt(aiTargeting.possibleTargetList[0].gameObj.transform.position);
                        agent.destination = transform.position;
                        preAttackEvent.Invoke();
                        yield return attackEventWaitObj;
                        
                        if (aiTargeting.possibleTargetList.Count != 0)
                        {
                            attackPosition = aiTargeting.possibleTargetList[0].gameObj.transform.position;
                            transform.LookAt(attackPosition);
                            agent.destination = attackPosition;
                            canAttack = false;
                            attacked = true;
                            ResetAttackCountdown();
                            StartCoroutine(AttackCooldown());
                        }
                        else
                        {
                            ResetAttackCountdown();
                            ChangeBase(backingBaseObj);
                        }
                    }
                    
                    if (Vector3.Distance(transform.position, attackPosition) < agent.stoppingDistance + 0.25f)
                    {
                        agent.velocity = Vector3.zero;
                        agent.destination = transform.position;
                        attackEvent.Invoke();
                        yield return postAttackWaitObj;
                        ChangeBase(backingBaseObj);
                    }
                }
                else
                {
                    ResetAttackCountdown();
                    ChangeBase(backingBaseObj);
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
        attacked = false;
    }
    //Special attack coroutine stuff here
}