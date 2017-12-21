using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public static Player instance;

	[HideInInspector]
	public Transform childPlayerP;
	[HideInInspector]
	public Animator playerAnimator;

	float playerMoveSpeed = 8.0f;
	public int hp = 100;

	void Start() {
		Player.instance = this;
		childPlayerP = transform.Find ("player");
		playerAnimator = childPlayerP.GetComponent<Animator> ();
		UseButton.instance.checkWeapon ();
	}

	void Update() {
		if (GameManager.gm.handGunP.activeSelf) {
			playerAnimator.SetBool ("IsGun", true);
		} else
			playerAnimator.SetBool ("IsGun", false);
		PlayerMove ();

		if (hp <= 0) {
			playerAnimator.SetTrigger ("Die");
		}
	}

	void PlayerMove() {
		if (JoystickCtrl.instance.drag == true) {
			transform.Translate (Vector3.forward * playerMoveSpeed * Time.timeScale * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, JoystickCtrl.instance.angle, 0);
			if (GameManager.gm.handGunP.activeSelf)
				playerAnimator.SetBool ("Walking", true);
		} else {
			if (GameManager.gm.handGunP.activeSelf)
				playerAnimator.SetBool ("Walking", false);
		}
	}

	public void PlayerShot() {
		Instantiate (GameManager.gm.bulletP, GameManager.gm.handGunShotP.transform.position, Quaternion.identity);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "BadMeat") {
			GameManager.gm.dropQ.Add ("Meat");
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "BadMeat") {
			GameManager.gm.dropQ.Add ("Water");
			Destroy (col.gameObject);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "BadMeat") {
			print ("meat");
			PlaceGroup.instance.addOne ("Meat");
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "BadWater") {
			print ("water");
			PlaceGroup.instance.addOne ("Water");
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "EnemyHand") {
			print ("hit");
			HpUIScript.instance.hpFillamout.fillAmount -= 10;
			hp -= 10;
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "BaseEnterGate" || col.gameObject.tag == "BaseExitGate") {
			UseButton.instance.useButton.sprite = UseButton.instance.openImage;
		} else if (col.gameObject.tag == "OxyzenGeneratorGate" || 
			col.gameObject.tag == "SpcUpgraderGate" || 
			col.gameObject.tag == "UpgraderGate" || 
			col.gameObject.tag == "PurifierGate" || 
			col.gameObject.tag == "SterilizerGate" || 
			col.gameObject.tag == "ChestGate") {
			UseButton.instance.useButton.sprite = UseButton.instance.useImage;
			switch (col.gameObject.tag) {
			case "OxyzenGeneratorGate":
				ButtonManager.instance.baseGateId = 0;
				break;
			case "SpcUpgraderGate":
				ButtonManager.instance.baseGateId = 1;
				break;
			case "UpgraderGate":
				ButtonManager.instance.baseGateId = 2;
				break;
			case "PurifierGate":
				ButtonManager.instance.baseGateId = 3;
				break;
			case "SterilizerGate":
				ButtonManager.instance.baseGateId = 4;
				break;
			case "ChestGate":
				ButtonManager.instance.baseGateId = 5;
				break;
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "BaseEnterGate" || col.gameObject.tag == "BaseExitGate") {
			UseButton.instance.checkWeapon ();
		}
	}
}
