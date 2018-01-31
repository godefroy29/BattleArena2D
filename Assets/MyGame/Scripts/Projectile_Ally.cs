using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Ally : MonoBehaviour {

    void OnCollisionEnter (Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "bulletAlly":
                Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
                break;
    
            case "enemy":
                Destroy(col.gameObject);
                Destroy(this.gameObject);
                break;

            case "block":
                Destroy(this.gameObject);
                break;

            default:
                break;
        }
    }
}