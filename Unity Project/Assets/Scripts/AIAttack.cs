using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Attack")]
public class AIAttack : AIBaseSO
{
    public float attackMomentumMultiplier = 2f;
    
    public override void BaseTask(NavMeshAgent agent)
    {
        //Change stopping distance and speed?
        stoppingDistance = 2.66f;
        speed = 9;
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
    }
}