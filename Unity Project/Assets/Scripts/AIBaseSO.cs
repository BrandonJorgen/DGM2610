using UnityEngine;
using UnityEngine.AI;

public abstract class AIBaseSO : ScriptableObject
{
    public float speed = 4.5f;
    public float angularSpeed = 120f;
    

    public virtual void BaseTask(NavMeshAgent agent)
    {
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
    }
}