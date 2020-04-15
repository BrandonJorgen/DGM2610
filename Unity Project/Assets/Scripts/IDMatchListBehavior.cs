using System;
using System.Collections.Generic;
using UnityEngine;

public class IDMatchListBehavior : IDMatch
{
    [Serializable]
    public struct nearbyEnemy
    {
        public GameObject enemyObj;
    }

    public List<nearbyEnemy> nearbyEnemyList;
    private nearbyEnemy enemyObj;

    private void Start()
    {
        enemyObj = new nearbyEnemy();
    }

    public void AddToList()
    {
        enemyObj.enemyObj = otherBehaviourObj.gameObject;
        
        nearbyEnemyList.Add(enemyObj);
    }
}