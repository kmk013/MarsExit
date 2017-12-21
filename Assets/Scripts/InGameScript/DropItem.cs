using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

	void LateUpdate () {
		transform.LookAt (GameManager.gm.mainPlayer.transform);
	}
}
