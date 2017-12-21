using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {
	public void InStart() {
		SceneManager.LoadScene ("ModeSelectScene");
	}

	public void InHelp() {
		SceneManager.LoadScene ("HowToPlayScene");
	}

	public void InTrophy() {
		SceneManager.LoadScene ("TrophyScene");
	}
}
