using UnityEngine;

[RequireComponent(typeof(IDMatchListBehavior))]
public class EnemyEngagedCheckBehavior : IDMatch
{
    private IDMatchListBehavior idMatchListObj;
    public GameObject gameObj;
    public IDName idOne;
    public AIBaseSO chaseBaseObjOne, chaseBaseObjTwo;

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
                if (currentEnemy.GetComponent<IDBehavior>().nameIdObj == idOne)
                {
                    currentEnemy.GetComponent<AIBrainBehavior>().ChangeBase(chaseBaseObjOne);
                }
                else
                {
                    currentEnemy.GetComponent<AIBrainBehavior>().ChangeBase(chaseBaseObjTwo);
                }
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