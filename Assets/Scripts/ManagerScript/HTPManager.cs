using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HTPManager : MonoBehaviour {
	int HTP_num;

	public GameObject[] HTP_BG;

	void Start () {
		HTP_num = 0;
		HTP_BG = new GameObject[5];
		for (int i = 0; i < 5; i++) {
			HTP_BG [i] = GameObject.Find ("HTP_BG_" + (i + 1));
		}
		for (int i = 1; i < 5; i++)
			HTP_BG [i].SetActive (false);
	}

	public void HTP_Prev() {
		HTP_num--;
		if (HTP_num == 0) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[0].SetActive (true);
		} else if (HTP_num == 1) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[1].SetActive (true);
		} else if (HTP_num == 2) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[2].SetActive (true);
		} else if (HTP_num == 3) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[3].SetActive (true);
		} else if (HTP_num == 4) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[4].SetActive (true);
		} else {
			if (HTP_num < 0)
				HTP_num = 0;
		}
	}

	public void HTP_Next() {
		HTP_num++;
		if (HTP_num == 0) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[0].SetActive (true);
		} else if (HTP_num == 1) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[1].SetActive (true);
		} else if (HTP_num == 2) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[2].SetActive (true);
		} else if (HTP_num == 3) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[3].SetActive (true);
		} else if (HTP_num == 4) {
			for (int i = 0; i < 5; i++)
				HTP_BG [i].SetActive (false);
			HTP_BG[4].SetActive (true);
		} else {
			if (HTP_num > 4)
				HTP_num = 4;
		}
	}

	public void HTP_BackButton() {
		SceneManager.LoadScene ("StartScene");
	}
}
