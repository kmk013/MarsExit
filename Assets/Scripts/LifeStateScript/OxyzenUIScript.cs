using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxyzenUIScript : MonoBehaviour {

	Image oxyzenFillamout;

	void Start() {
		oxyzenFillamout = GetComponent<Image> ();
	}

	void Update () {
		oxyzenFillamout.fillAmount -= Time.deltaTime * Time.timeScale * 0.01f;
	}
}
