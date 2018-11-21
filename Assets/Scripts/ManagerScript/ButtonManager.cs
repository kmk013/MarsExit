using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public static ButtonManager instance;
	Vector3 playerBasePosition;
	public int baseGateId;

	void Start() {
		ButtonManager.instance = this;
	}

	public void InStart() {
		SceneManager.LoadScene ("ModeSelectScene");
	}

	public void InHelp() {

	}

	public void InTrophy() {

	}

	public void InSurvival() {
		SceneManager.LoadScene ("GameScene");
	}

	public void InPause() {
		Time.timeScale = 0;
		GameManager.gm.ingameUIG.SetActive (false);
		GameManager.gm.pauseUIG.SetActive (true);
		GameManager.gm.firstPauseUIG.SetActive (true);
	}

	public void OutPause() {
		Time.timeScale = 1;
		GameManager.gm.ingameUIG.SetActive (true);
		GameManager.gm.pauseUIG.SetActive (false);
		GameManager.gm.inventoryUIG.SetActive (false);
		GameManager.gm.mapUIG.SetActive (false);
		GameManager.gm.settingUIG.SetActive (false);
	}

	public void InInventory() {
		GameManager.gm.firstPauseUIG.SetActive (false);
		GameManager.gm.inventoryUIG.SetActive (true);
		GameManager.gm.mapUIG.SetActive (false);
		GameManager.gm.settingUIG.SetActive (false);
	}

	public void InMap() {
		GameManager.gm.firstPauseUIG.SetActive (false);
		GameManager.gm.inventoryUIG.SetActive (false);
		GameManager.gm.mapUIG.SetActive (true);
		GameManager.gm.settingUIG.SetActive (false);
	}

	public void InSetting(){
		GameManager.gm.firstPauseUIG.SetActive (false);
		GameManager.gm.inventoryUIG.SetActive (false);
		GameManager.gm.mapUIG.SetActive (false);
		GameManager.gm.settingUIG.SetActive (true);
	}

	public void UseButtonOn() {
		if (UseButton.instance.useButton.sprite.name == "Use") {
			switch (baseGateId) {
			case 0:
				GameManager.gm.OxyzenGeneratorUIG.SetActive (true);
				break;
			case 1:
				GameManager.gm.SpecialUpgraderUIG.SetActive (true);
				break;
			case 2:
				GameManager.gm.BagicUpgraderUIG.SetActive (true);
				break;
			case 3:
				GameManager.gm.PurifierUIG.SetActive (true);
				break;
			case 4:
				GameManager.gm.SterilizerUIG.SetActive (true);
				break;
			case 5:
				GameManager.gm.ChestUIG.SetActive (true);
				break;
			}
		} else if (UseButton.instance.useButton.sprite.name == ("Shoot")) {
			Player.instance.PlayerShot ();
			Player.instance.playerAnimator.SetTrigger ("Shotting");
		} else if (UseButton.instance.useButton.sprite.name == ("Open")) {
			if (GameManager.gm.mainPlayer.transform.position.y < 100) {
				playerBasePosition = GameManager.gm.mainPlayer.transform.position;
				GameManager.gm.mainPlayer.transform.position = GameManager.gm.baseExitGateP.transform.position;
				GameManager.gm.mainCamera.transform.SetParent (GameManager.gm.mainPlayer.transform);
//				GameManager.gm.mainCamera.GetComponent<Camera>().
			} else {
				GameManager.gm.mainPlayer.transform.position = playerBasePosition;
				GameManager.gm.mainCamera.transform.parent = null;
			}
		} else if (UseButton.instance.useButton.sprite.name == ("Dig")) {

		}
	}

	public void basicUpgraderClose() {
		GameManager.gm.BagicUpgraderUIG.SetActive (false);
	}

	public void basicUpgraderBack() {
		GameManager.gm.BagicUpgrader_NextUIG.SetActive (false);
		GameManager.gm.BagicUpgraderUIG.SetActive (true);
	}

	public void OxyzenGeneratorClose() {
		GameManager.gm.OxyzenGeneratorUIG.SetActive (false);
	}

	public void PurifierClose() {
		GameManager.gm.PurifierUIG.SetActive (false);
	}

	public void SterilizerClose() {
		GameManager.gm.SterilizerUIG.SetActive (false);
	}

	public void SpecialUpgraderClose() {
		GameManager.gm.SpecialUpgraderUIG.SetActive (false);
	}

	public void SpecialUpgraderBack() {
		GameManager.gm.SpecialUpgrader_NextUIG.SetActive (false);
		GameManager.gm.SpecialUpgraderUIG.SetActive (true);
	}

	public void ChestClose() {
		GameManager.gm.ChestUIG.SetActive (false);
	}
}
