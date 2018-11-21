using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodUIScript : MonoBehaviour {

	Image foodFillamout;

	void Start() {
		foodFillamout = GetComponent<Image> ();
	}

	void Update () {
		foodFillamout.fillAmount -= Time.deltaTime * Time.timeScale * 0.003f;
	}
}
