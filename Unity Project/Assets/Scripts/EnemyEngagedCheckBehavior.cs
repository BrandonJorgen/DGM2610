using UnityEngine;

[RequireComponent(typeof(IDMatchListBehavior))]
public class EnemyEngagedCheckBehavior : IDMatch
{
    private IDMatchListBehavior idMatchListObj;
    public GameObject gameObj;
    public AIBaseSO chaseBaseObj;

    private void Start()
    {
        idMatchListObj = GetComponent<IDMatchListBehavior>();
    }

    public void AlertToggle()
    {
        if (idMatchListObj.nearbyEnemyList.Count != 0)
        {
            foreach (var obj in idMatchListObj.nearbyEnemyList)
            {
                var currentEnemy = obj.enemyObj;
                if (currentEnemy == null) return;
                currentEnemy.GetComponentInChildren<EnemyEngagedCheckBehavior>().gameObj = gameObj;
                currentEnemy.GetComponentInChildren<AITargetingBehavior>().AddObjToList(gameObj);
                currentEnemy.GetComponent<AIBrainBehavior>().ChangeBase(chaseBaseObj);
            }
        }
    }

    public void SetGameObj()
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                gameObj = otherBehaviourObj.gameObject;
            }
        }
    }
}