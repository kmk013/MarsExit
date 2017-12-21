using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	//5초
	float bulletSpeed = 25.0f;
	float bulletTime = 0;

	void Start() {
		transform.rotation = GameManager.gm.mainPlayer.transform.rotation;
	}

	void Update () {
		transform.Translate (Vector3.forward * bulletSpeed * Time.deltaTime * Time.timeScale);

		bulletTime += Time.deltaTime;
		if (bulletTime >= 5.0f)
			Destroy (this.gameObject);
	}
}
