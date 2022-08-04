using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class chunkScript : MonoBehaviour
{
    public void init (Vector2 Startposition)
    {
        transform.position = Startposition;
        transform.DOMoveX(-5000f ,2 ).SetSpeedBased();
    }
}
