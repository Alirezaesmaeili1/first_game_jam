using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float _speed ;

    public void init(float speed){
        this._speed = speed ;
        Destroy(gameObject,5f);
    }
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        Vector2 direction = transform.position;
        transform.position = Vector2.Lerp(transform.position, direction, 5f);
    }
}