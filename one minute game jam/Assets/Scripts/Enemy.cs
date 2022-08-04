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
    public Transform StartPoint , EndPoint;
    public Transform[] MovePoint; 
    private List<Vector3> _WayPoint = new List<Vector3>();

   
    private void Start()
    {
        init();
        CrapPath();
       
    }

    
    void init()
    {
        transform.position=StartPoint.position;
        switch(enemytype)
        {
            case Enemytype.crap:
                CrapType();
                break ;

        }
    }

    void CrapType(){
        transform.DOMove(NewPosition , speed);
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
        transform.DOPath(_WayPoint.ToArray(),3f,PathType.CatmullRom,PathMode.Sidescroller2D).SetDelay(1f).SetEase(Ease.Linear);
        
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
public enum Enemytype
{
    fish , crap , squid , Seashell 

}
