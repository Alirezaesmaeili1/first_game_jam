using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage ; 
    private float _speed  ; 

    public void init(float speed ){
        this._speed = speed ;
        Destroy(gameObject,5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); 

        } 

        
    }
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        Vector2 direction = transform.position;
        transform.position = Vector2.Lerp(transform.position, direction, 5f);
    }
}
