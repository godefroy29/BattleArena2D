using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  
	public GameObject cible;
     public float moveSpeed;
     public GameObject startPosObject;
     public float addX;
     public float addY;

     void Start () {
		 GetComponent<Rigidbody>().freezeRotation = true;
     }
     
     // Update is called once per frame
     void Update () {
		transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x, transform.position.y), new Vector2(cible.transform.position.x, cible.transform.position.y), moveSpeed * Time.deltaTime );
     }

	 void OnCollisionEnter (Collision col)
    {
        if(col.gameObject == cible)
        {
            Destroy(cible);
        }
		else if(col.gameObject.tag == "block")
		{
			//Destroy(this.gameObject);
            transform.position = new Vector2(startPosObject.transform.position.x + addX, startPosObject.transform.position.y + addY);//startPosObject.transform.position;
		}
    }

}
