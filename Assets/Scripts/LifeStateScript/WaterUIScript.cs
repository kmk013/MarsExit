using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUIScript : MonoBehaviour {

	Image waterFillamout;

	void Start() {
		waterFillamout = GetComponent<Image> ();
	}

	void Update () {
		waterFillamout.fillAmount -= Time.deltaTime * Time.timeScale * 0.002f;
	}
}
