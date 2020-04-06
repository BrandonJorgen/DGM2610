using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBrainBehavior : MonoBehaviour
{
    public AIBaseSO aiBaseObj;

    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    private bool CanRun;
    private Vector3 spawnLoc;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnLoc = transform.position;
        StartCoroutine(Start());
    }

    private IEnumerator Start()
    {
        CanRun = true;
        while (CanRun)
        {
            aiBaseObj.BaseTask(agent);
            yield return waitObj;
        }
    }

    public void ChangeBase(AIBaseSO obj)
    {
        aiBaseObj = obj;
    }
    
    //Swap to return to spawn after chase is activated and target list is 0
    public void ReturnToSpawn()
    {
        agent.destination = spawnLoc;
    }
}