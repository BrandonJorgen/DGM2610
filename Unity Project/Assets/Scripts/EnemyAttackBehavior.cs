using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackBehavior : MonoBehaviour
{
    private bool playerInRange;
    public float attackCooldown = 1f;

    public UnityEvent playerInRangeEvent;

    public void Attack()
    {
        if (playerInRange)
        {
            playerInRangeEvent.Invoke();
            StartCoroutine(AttackCooldown());
        }
    }

    public void PlayerInRange()
    {
        playerInRange = true;
    }

    public void PlayerNotInRange()
    {
        playerInRange = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);

        if (playerInRange)
        {
            Attack();
        }
    }
}