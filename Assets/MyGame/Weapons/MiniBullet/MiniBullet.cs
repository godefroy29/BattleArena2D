using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : Weapon {

	void OnDestroy() {
        // GameObject smokePuff = Instantiate(smoke, transform.position, transform.rotation) as GameObject;
		// ParticleSystem parts = smokePuff.GetComponent<ParticleSystem>();
		// float totalDuration = parts.main.duration + parts.startLifetime;
		// Destroy(smokePuff, totalDuration);
    }
}
