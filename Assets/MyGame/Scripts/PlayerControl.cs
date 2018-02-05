using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    public GameObject bullet;
	public float bulletSpeed;
	public float moveSpeed;
    public float addX;
    public float fireDelayMillisec;
    private System.DateTime lastFiredBullet;


    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
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
 
        movement = movement + (Vector2)(transform.position);
 
        GetComponent<Rigidbody>().MovePosition(movement);
    }

    
    void fire(int directionX)
    {
        if((System.DateTime.Now - lastFiredBullet).TotalMilliseconds >= fireDelayMillisec)
        {
            GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x + directionX * addX, transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), GetComponent<Collider>());
            bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(directionX * 1,0,0) * bulletSpeed;
            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            lastFiredBullet = System.DateTime.Now;
        }
    }


    
    void melee(int directionX)
    {
        if((System.DateTime.Now - lastFiredBullet).TotalMilliseconds >= fireDelayMillisec)
        {
            GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x + directionX * addX, transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), GetComponent<Collider>());
            bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(directionX * 1,0,0) * bulletSpeed;
            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            lastFiredBullet = System.DateTime.Now;
        }
    }
}
