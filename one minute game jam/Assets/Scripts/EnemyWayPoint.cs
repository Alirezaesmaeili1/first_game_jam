using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPoint : MonoBehaviour
{
    public EnemyWayPointType type ;
    public Transform StartPoint , EndPoint;
    public Transform[] MovePoint; 
}
