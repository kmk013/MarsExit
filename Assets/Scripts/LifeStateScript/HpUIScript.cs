using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUIScript : MonoBehaviour {

	public static HpUIScript instance;
	public Image hpFillamout;

	void Start() {
		HpUIScript.instance = this;
		hpFillamout = GetComponent<Image> ();
	}
}
