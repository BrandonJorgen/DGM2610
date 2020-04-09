using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Backing")]
public class AIBacking : AIBaseSO
{
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
        agent.radius = avoidanceRadius;
        agent.angularSpeed = angularSpeed;
        agent.autoBraking = autoBraking;
        agent.acceleration = acceleration;
    }
}