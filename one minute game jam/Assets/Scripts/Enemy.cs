using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [Header("Global Settings")]
    public float health = 1  , speed ;
    public Enemytype enemytype ; 

    [Header("t setting")]
    public Vector2 NewPosition ; 

    [Header("path Settings")]
    public bool Moveing = false; 
    public float SpeedMoveing =3f; 
    public Transform StartPoint , EndPoint;
    public Transform[] MovePoint; 
    private List<Vector3> _WayPoint = new List<Vector3>();
    private float _delaySpawn ;

   
    public void init(EnemyWayPoint enemywaypoint , float delaySpead)
    {
        StartPoint=enemywaypoint.StartPoint;
        MovePoint=enemywaypoint.MovePoint;
        EndPoint=enemywaypoint.EndPoint;
        transform.position=StartPoint.position;
        _delaySpawn=delaySpead;
        switch(enemytype)
        {
            case Enemytype.crap:
                CrapPath();
                break ;
            
        }
        
    }
    void CrapPath()
    {
        if(MovePoint.Length>0){
            foreach (Transform movepoint in MovePoint)
            {
                _WayPoint.Add(movepoint.position);
            }
        }
        _WayPoint.Add(EndPoint.position); 
        transform.DOPath(_WayPoint.ToArray(),SpeedMoveing,PathType.CatmullRom,PathMode.Sidescroller2D)
        .SetDelay(_delaySpawn)
        .SetEase(Ease.Linear)
        .SetLookAt(0.01f)
        .SetSpeedBased(true);
        if (transform.position == EndPoint.position)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage (float damage)
    {
        health -= damage ; 
        if (health<=0)
        {
            DieEnemy();
        }
    }
    void DieEnemy ()
    {
        Destroy(gameObject);
    }
}
