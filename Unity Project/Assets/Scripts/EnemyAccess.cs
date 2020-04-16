using UnityEngine;

public class EnemyAccess : MonoBehaviour
{
    public FloatDataSO knockBackDistance, playerDamage;

    private TransformBehavior enemyObj;
    private InstantiatedFloatDataBehavior enemyHealthBehavior;
    private InstantiatedValueCheckBehavior enemyHealthCheck;
    
    private void OnTriggerEnter(Collider other)
    {
        enemyObj = other.GetComponent<TransformBehavior>();
        enemyHealthBehavior = other.GetComponent<InstantiatedFloatDataBehavior>();
        enemyHealthCheck = other.GetComponent<InstantiatedValueCheckBehavior>();
        
        if (enemyObj == null || enemyHealthBehavior == null || enemyHealthCheck == null)
        {
            return;
        }
        
        enemyObj.KnockbackFloatArg(knockBackDistance.value);
        enemyHealthBehavior.dataObj.value -= playerDamage.value;
        enemyHealthCheck.CheckValue(0);
    }
}