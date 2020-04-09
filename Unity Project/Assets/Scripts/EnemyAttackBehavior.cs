using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackBehavior : MonoBehaviour
{
    private bool playerInRange;

    public UnityEvent playerInRangeEvent;

    public void Attack()
    {
        playerInRangeEvent.Invoke();
    }
}