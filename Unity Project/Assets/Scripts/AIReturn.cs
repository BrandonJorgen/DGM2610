using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Return")]
public class AIReturn : AIBaseSO
{
    
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.angularSpeed = angularSpeed;
        agent.radius = avoidanceRadius;
        agent.acceleration = acceleration;
        agent.autoBraking = autoBraking;
    }
}