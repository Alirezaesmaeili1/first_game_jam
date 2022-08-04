using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MovementType  movementType ;
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
      if (Input.GetMouseButton(1))
      {
          shooting();
      }
    }

    void init(){
        if (movementType == MovementType.Joystick)
        {
            joystick.gameObject.SetActive(true);

        }
        else
        {
            joystick.gameObject.SetActive(false);
        }
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
    void movement()
    {
       switch (movementType)
       {
           case MovementType.Joystick:
               {
                  JoystickMovement(); 
                   break;
               }
           case MovementType.Mouse:
               {
                   MouseMovement();
                   break;
               }
            default :
               {
                  MouseMovement();
                   break;
               }
       }

    }
    void JoystickMovement(){
        Vector2 direction = transform.position;
        direction += new Vector2(joystick.Horizontal* speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime);
        direction.x = Mathf.Clamp(direction.x, -13f, 13f);
        direction.y = Mathf.Clamp(direction.y, -4f, 4f);
        transform.position = Vector2.Lerp(transform.position, direction, smoothness);
    } 
    void MouseMovement(){
        Vector3 MousePosition = new Vector3 ();
       if (Input.GetMouseButton(0))
       {
          MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          MousePosition.z = 0;
          float delta = speed * Time.deltaTime;
          delta *= Vector3.Distance(transform.position, MousePosition);
           transform.position = Vector3.MoveTowards(transform.position, MousePosition, delta);
       }
    }
}
public enum MovementType
{
    Joystick,
    Mouse,
}