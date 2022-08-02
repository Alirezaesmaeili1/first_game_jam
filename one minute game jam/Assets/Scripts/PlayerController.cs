using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed ; 
    public float smoothness ;
    public Joystick joystick;
    public float shootSpeed ;
    public GameObject bullet ;
    public float bulletSpeed ;
    private float _holdShootingspeed ;


    public Transform[] shootingposes;

   

    private void Start() {
       init();       
    }
 
    
    void Update()
    {
       movement();
       shooting();
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

    
    void movement(){
        Vector2 direction = transform.position;
        direction += new Vector2(joystick.Horizontal* speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime);
        direction.x = Mathf.Clamp(direction.x, -13f, 13f);
        direction.y = Mathf.Clamp(direction.y, -4f, 4f);
        transform.position = Vector2.Lerp(transform.position, direction, smoothness);
    } 
}
