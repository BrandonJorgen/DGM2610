using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Hover")]
public class AIHover : AIBaseSO
{
    public Vector3SO targetV3;
    
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.angularSpeed = angularSpeed;
        agent.speed = speed;
        agent.radius = avoidanceRadius;
        agent.acceleration = acceleration;
        agent.destination = targetV3.vector3;
    }
}