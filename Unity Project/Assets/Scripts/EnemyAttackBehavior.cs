using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackBehavior : MonoBehaviour
{
    private bool playerInRange;
    public float attackCooldown = 1f;

    public UnityEvent playerInRangeEvent;

    public void InitiateAttackSequence()
    {
        StartCoroutine(AttackSequence());
    }

    public void Attack()
    {
        playerInRangeEvent.Invoke();
    }
    
    public void PlayerInRange()
    {
        playerInRange = true;
    }

    public void PlayerNotInRange()
    {
        playerInRange = false;
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(1f);

        while (playerInRange)
        {
            Attack();
        
            yield return new WaitForSeconds(attackCooldown);
        }
    }
    
    //Maybe add some sort of combat memory here to prevent the immediate 1 second attack if the player knocks the enemy
    //back and re-enters attack range
}