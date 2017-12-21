using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseButton : MonoBehaviour {

	public static UseButton instance;
	public Image useButton;

	public Sprite useImage;
	public Sprite shootImage;
	public Sprite openImage;
	public Sprite digImage;

	void Start() {
		UseButton.instance = this;

		useButton = GetComponent<Image> ();
	}

	void Update () {
		//checkWeapon ();
	}

	public void checkWeapon() {
		if (GameManager.gm.handGunP.activeSelf)
			useButton.sprite = shootImage;
		else
			useButton.sprite = useImage;
	}
}
