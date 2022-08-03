using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1  ;
    public Enemytype enemytype ; 
    private void Start ()
    {
        transform.DOMove(new Vector2(3 , 3),3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(other); 
    }
    
    void TakeDamage (Collider2D other)
    {
        if (!other.CompareTag("Bullet")&&!other.CompareTag("Shark")) return ; 

        bullet _tempbullet = other.GetComponent<bullet>();
        health -= _tempbullet.damage ; 
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
    fish , crap , squid 

}
