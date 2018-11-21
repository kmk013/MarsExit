using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public static Enemy instance;

	public float enemyMovespeed = .01f;
	public float enemyScreamTime = 2.8f;
	public float enemyScreamTicktime = 0;
	public float distance;
	Animator enemyAnim;

	int hp = 50;

	void Start() {
		Enemy.instance = this;
		enemyAnim = GetComponent<Animator> ();
	}

	void Update () {
		distance = Vector3.Distance (GameManager.gm.mainPlayer.transform.position, transform.position);

		if (distance < 20f) {
			transform.LookAt (GameManager.gm.mainPlayer.transform);
//			GameManager.gm.mainPlayer.transform.LookAt (transform);
			enemyAnim.SetBool ("Screaming", true);
			Invoke ("Walking", 2.5f);
		} else {
			enemyAnim.SetBool ("Screaming", false);
			enemyAnim.SetBool ("Walking", false);
			enemyScreamTicktime = 0;
		}

		if (hp <= 0) {
			enemyAnim.SetTrigger ("Die");
			Invoke ("destory", 4.6f);
		}
	}

	void Walking() {
		enemyAnim.SetBool ("Walking", true);

		if (distance < 7f)
			AttackToWalk ();
		else
			transform.position = Vector3.Lerp (
				transform.position,
				GameManager.gm.mainPlayer.transform.position, 
				Time.deltaTime * .25f
			);
	}

	void AttackToWalk() {
		enemyAnim.SetTrigger ("AttackToWalk");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			hp -= 10;
		}
	}

	void destory() {
		Destroy (this.gameObject);
	}
}
