using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Weapon : MonoBehaviour {


    public GameObject slot1_bullet;
    public GameObject slot2_bullet;
    public GameObject slot3_bullet;
	public float bulletSpeed;
	public float moveSpeed;
    public float addX;
    public float fireDelayMillisec;
    private System.DateTime lastFiredBullet;
    private GameObject currentGameObject;


    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        currentGameObject = slot1_bullet;
    }


    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
 
        if(Input.GetKey(KeyCode.Q))
        {
            movement.x = (transform.right*Time.deltaTime*-moveSpeed).x;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement.x = (transform.right*Time.deltaTime*moveSpeed).x;
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z))
        {
            movement.y = (transform.up*Time.deltaTime*moveSpeed).y;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            fire(-1);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            fire(1);
        }
        if(Input.GetKey(KeyCode.Keypad1))
        {
            currentGameObject = slot1_bullet;
        }
        if(Input.GetKey(KeyCode.Keypad2))
        {
            currentGameObject = slot2_bullet;
        }
        if(Input.GetKey(KeyCode.Keypad3))
        {
            currentGameObject = slot3_bullet;
        }
 
        movement = movement + (Vector2)(transform.position);
 
        GetComponent<Rigidbody>().MovePosition(movement);
    }

    
    void fire(int directionX)
    {
        if((System.DateTime.Now - lastFiredBullet).TotalMilliseconds >= fireDelayMillisec)
        {
            GameObject bulletInstance = Instantiate(currentGameObject, new Vector3(transform.position.x + directionX * addX, transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), GetComponent<Collider>());
            Weapon weaponInstance = bulletInstance.GetComponent<Weapon>();
            weaponInstance.InitVar(fireDelayMillisec, bulletSpeed, directionX, null, true, true, new string[]{"block"},  new string[]{"enemy"},  new string[]{"bulletAlly"});
            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            lastFiredBullet = System.DateTime.Now;
        }
    }
}
