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

    public void AddToList()
    {
        nearbyEnemy enemy = new nearbyEnemy();
        enemy.enemyObj = otherBehaviourObj.gameObject;
        
        nearbyEnemyList.Add(enemy);
    }
}