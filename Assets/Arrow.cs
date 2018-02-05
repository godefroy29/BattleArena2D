using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon {

    public float deltaX;
    public float deltaY;
 
    void Start()
    {
        this.transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(this.transform.right, new Vector3(orientationX * deltaX * moveSpeed, deltaY * moveSpeed, 0).normalized)));
        GetComponent<Rigidbody>().AddForce(new Vector3(orientationX * deltaX * moveSpeed, deltaY * moveSpeed, 0), ForceMode.Impulse);
    }
 
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(this.transform.right, GetComponent<Rigidbody>().velocity.normalized)));
    }
    void Update()
    {

    }
}
