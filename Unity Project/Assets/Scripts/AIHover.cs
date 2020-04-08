using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Hover")]
public class AIHover : AIBaseSO
{
    public Vector3SO targetV3;
    
    public override void BaseTask(NavMeshAgent agent)
    {
        stoppingDistance = 5f;
        speed = 2.25f;
        avoidanceRadius = 2f;
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
        agent.radius = avoidanceRadius;
        agent.destination = targetV3.vector3;
    }
}