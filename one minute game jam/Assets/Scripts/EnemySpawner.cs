using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemytype enemytype ; 
    public EnemyWayPointType enemyWayPointType ;
    public int Count = 5 ; 
    public float delaySpead = 1f ;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy Maker"))
        GameManager.I.MakeEnemies(enemytype,enemyWayPointType,Count,delaySpead);
    }
}
