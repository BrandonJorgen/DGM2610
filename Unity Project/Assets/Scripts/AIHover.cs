using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Hover")]
public class AIHover : AIBaseSO
{
    public Vector3SO targetV3;
    public WaitForSeconds waitObj = new WaitForSeconds(1f);
    
    public override void BaseTask(NavMeshAgent agent)
    {
        stoppingDistance = 4f;
        agent.stoppingDistance = stoppingDistance;
        agent.destination = targetV3.vector3;
    }

    public void InitiateCoroutine()
    {
        
    }
}