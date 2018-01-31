using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

     public Transform player;
     public float moveSpeed;
      
 
     // Use this for initialization
     void Start () {
		 GetComponent<Rigidbody>().freezeRotation = true;
         GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
     }
     
     // Update is called once per frame
     void Update () {
	    transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x, transform.position.y), new Vector2(player.position.x, transform.position.y), moveSpeed * Time.deltaTime );
     }

}
