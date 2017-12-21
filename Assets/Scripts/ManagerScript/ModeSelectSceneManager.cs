using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectSceneManager : MonoBehaviour {

	public void InSurvival() {
		SceneManager.LoadScene ("GameScene");
	}

	public void ModeSelectSceneBackButton() {
		SceneManager.LoadScene ("StartScene");
	}
}
