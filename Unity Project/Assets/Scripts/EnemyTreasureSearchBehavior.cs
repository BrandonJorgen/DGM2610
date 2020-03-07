using UnityEngine;
using UnityEngine.AI;

public class EnemyTreasureSearchBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    
    private void OnTriggerEnter(Collider other)
    {
        agent.destination = other.transform.position;
    }
}