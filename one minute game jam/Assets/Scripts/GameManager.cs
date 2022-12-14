using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
   public static GameManager I ;
   public List<GameObject> EnemyPrefab = new List<GameObject>();
   public List<EnemyWayPoint> enemyWayPoints = new List<EnemyWayPoint>();
   public List<Transform> Chunks = new List<Transform>();
   private int ChunksIndex = 0 ;
   private void Start()
   {
    MakeChunk ();
   }
   private void Awake()
    {
        if (I!= this)
        {
            I = this;
        }
    }
   void MakeChunk()
   {
        Transform tmpchunk = Instantiate(Chunks[ChunksIndex],transform);
        tmpchunk.GetComponent<chunkScript>().init(new Vector2 (0,0));
   }
   public void MakeEnemies(Enemytype enemytype , EnemyWayPointType enemyWayPointType ,int Count,float delaySpead)
   {
       for (int i = 0; i < Count; i++)
       {
           MakeEnemy(enemytype,enemyWayPointType , delaySpead * i);
       }
   }
   void MakeEnemy(Enemytype enemytype , EnemyWayPointType enemyWayPointType  ,float delaySpead)
   {
      GameObject enemybyType = null ; 
      switch (enemytype)
      {
        case Enemytype.Crap:
            enemybyType = EnemyPrefab[0];
            break;
        case Enemytype.Seashell:
            enemybyType = EnemyPrefab[1];
            break;
      }
      EnemyWayPoint _enemyWayPoint = enemyWayPoints.Find(x => x.type== enemyWayPointType);

      GameObject enemy = Instantiate(enemybyType ,_enemyWayPoint.StartPoint.position,Quaternion.identity);
      enemy.GetComponent<Enemy>().init(_enemyWayPoint,delaySpead);
   }
}
public enum EnemyWayPointType
{
    way1,
    way2,
    way3,
    way4,
}
public enum Enemytype
{
    Fish ,
    Crap ,
    Squid ,
    Seashell ,
}

