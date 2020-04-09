using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Idle")]
public class AIIdle : AIBaseSO
{
    public override void BaseTask(NavMeshAgent agent)
    {
        agent.autoBraking = autoBraking;
        agent.acceleration = acceleration;
    }
}