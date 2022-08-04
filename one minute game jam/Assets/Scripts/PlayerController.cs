using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed , smoothness , shootSpeed , bulletSpeed , damage ;
    public Joystick joystick;
    public GameObject bullet ;
    private float _holdShootingspeed ;
    public Transform[] shootingposes;
    [SerializeField] KeyCode your_key;
   

    private void Start() {
       init();       
    }
    
    void Update()
    {
       movement();
       if (Input.GetKey(your_key))
       {
           shooting();
       }
    }

    void init(){
        _holdShootingspeed = shootSpeed ;
    }
    void shooting(){
        if(shootingposes.Length  <= 0) return ;
        _holdShootingspeed -= Time.deltaTime ;
        if (_holdShootingspeed <= 0)
        {
            foreach (Transform shootingPositions in shootingposes )
            {
                GameObject bulletClone = Instantiate(bullet, shootingPositions.position, Quaternion.identity);
                bulletClone.GetComponent<bullet>().init(bulletSpeed);

            }
            _holdShootingspeed = shootSpeed ;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        } 
    }

    
    void movement(){
        Vector2 direction = transform.position;
        direction += new Vector2(joystick.Horizontal* speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime);
        direction.x = Mathf.Clamp(direction.x, -13f, 13f);
        direction.y = Mathf.Clamp(direction.y, -4f, 4f);
        transform.position = Vector2.Lerp(transform.position, direction, smoothness);
    } 
}
