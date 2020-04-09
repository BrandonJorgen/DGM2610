using UnityEngine;
using UnityEngine.AI;

public abstract class AIBaseSO : ScriptableObject
{
    public float speed = 4.5f, angularSpeed = 120f, stoppingDistance = 2.66f, avoidanceRadius = 0.8f, acceleration = 8f;
    public bool autoBraking;

    public virtual void BaseTask(NavMeshAgent agent)
    {
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
        agent.stoppingDistance = stoppingDistance;
        agent.radius = avoidanceRadius;
        agent.autoBraking = autoBraking;
        agent.acceleration = acceleration;
    }
}