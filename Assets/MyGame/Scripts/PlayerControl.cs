using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    public GameObject bullet;
    
	public float moveSpeed;
	public float bulletSpeed;
    public float addX;
    public float fireDelayMillisec;
    private System.DateTime lastFiredBullet;
	private KeyCode RightKey = KeyCode.D; //shortcut
	private KeyCode LeftKey = KeyCode.Q; //shortcut
	private KeyCode UpKey = KeyCode.Z; //shortcut
    private KeyCode FireLeftKey = KeyCode.LeftArrow;
    private KeyCode FireRightKey = KeyCode.RightArrow;
    private bool freezeRotation = true;


    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;
 
        if(Input.GetKey(LeftKey))
        {
            movement.x = (transform.right*Time.deltaTime*-moveSpeed).x;
        }
        if(Input.GetKey(RightKey))
        {
            movement.x = (transform.right*Time.deltaTime*moveSpeed).x;
        }
        if(Input.GetKey(UpKey))
        {
            movement.y = (transform.up*Time.deltaTime*moveSpeed).y;
        }
 
        movement = movement + (Vector2)(transform.position);
 
        GetComponent<Rigidbody>().MovePosition(movement);

            
        if((System.DateTime.Now - lastFiredBullet).TotalMilliseconds >= fireDelayMillisec)
        {
            if (Input.GetKey(FireLeftKey))
            {
                GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x - addX, transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(-1,0,0) * bulletSpeed;
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            }
            if (Input.GetKey(FireRightKey))
            {
                GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x + addX, transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bulletInstance.GetComponent<Rigidbody>().velocity = new Vector3(1,0,0) * bulletSpeed;
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            }

            lastFiredBullet = System.DateTime.Now;
       }
    }	
}
