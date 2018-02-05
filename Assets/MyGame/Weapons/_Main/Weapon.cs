using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private float delay;
	private float moveSpeed;
	private float orientationX;
	private GameObject gameObjectToFollow;
	private bool freezeRotate;
	private bool freezeY;
	private string[] tagsDestroyMe;
	private string[] tagsToDestroy;
	private string[] tagsIgnoreCollider;

    void Update () {

		if(gameObjectToFollow != null)
		{
        	transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x, transform.position.y), new Vector2(gameObjectToFollow.transform.position.x, gameObjectToFollow.transform.position.y), moveSpeed * Time.deltaTime );
		}
	}

	public void InitVar(float delay, float moveSpeed, float orientationX, GameObject gameObjectToFollow, bool freezeRotate, bool freezeY, string[] tagsDestroyMe, string[] tagsToDestroy, string[] tagsIgnoreCollider)
	{
		this.delay = delay;
		this.moveSpeed = moveSpeed;
		this.gameObjectToFollow = gameObjectToFollow;
		this.freezeRotate = freezeRotate;
		this.freezeY = freezeY;
		this.tagsDestroyMe = tagsDestroyMe;
		this.tagsToDestroy = tagsToDestroy;
		this.tagsIgnoreCollider = tagsIgnoreCollider;
		this.orientationX = orientationX;
		if(gameObjectToFollow == null)
		{
			//GetComponent<Rigidbody>().AddForce(new Vector3(moveSpeed,0,0), ForceMode.Impulse);
			GetComponent<Rigidbody>().velocity = new Vector3(orientationX,0,0) * moveSpeed;
		}
	}

	void OnCollisionEnter (Collision col)
    {
		if(Array.Exists(tagsIgnoreCollider, element => element == col.gameObject.tag))
		{
			Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
		}
		else if(Array.Exists(tagsToDestroy, element => element == col.gameObject.tag))
		{
			Destroy(col.gameObject);
		}
		else if(Array.Exists(tagsDestroyMe, element => element == col.gameObject.tag))
		{
			Destroy(this.gameObject);
		}
    }

	private void setVar()
	{
		GetComponent<Rigidbody>().freezeRotation = freezeRotate;
	}
}
