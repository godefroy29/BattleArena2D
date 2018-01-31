using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	private KeyCode RightKey = KeyCode.D; //shortcut
	private KeyCode LeftKey = KeyCode.Q; //shortcut
	private KeyCode UpKey = KeyCode.Z; //shortcut
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
	}
}
