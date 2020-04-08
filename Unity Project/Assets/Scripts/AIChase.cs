using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Chase")]
public class AIChase : AIBaseSO
{
    public Vector3SO targetV3;
    
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
        agent.radius = avoidanceRadius;
        agent.destination = targetV3.vector3;
    }
}