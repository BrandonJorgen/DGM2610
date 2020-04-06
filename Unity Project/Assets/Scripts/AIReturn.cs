using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Return")]
public class AIReturn : AIBaseSO
{
    
    public override void BaseTask(NavMeshAgent agent)
    {
        stoppingDistance = 0f;
        agent.stoppingDistance = stoppingDistance;
    }
}