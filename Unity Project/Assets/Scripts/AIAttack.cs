using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Attack")]
public class AIAttack : AIBaseSO
{
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
        agent.autoBraking = autoBraking;
        agent.acceleration = acceleration;
    }
}