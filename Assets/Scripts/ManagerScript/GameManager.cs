using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public string playerName = null;
	public int aliveTime = 0;
	public float totalPlayTime = 0;
	public int myDieCnt = 0;
	public int myMonsterKillCnt = 0;

	public GameObject mainCamera;
	public GameObject mainMapTreeP;

	public GameObject playerP;
	public GameObject enemyP;
	public GameObject mapP;
	public GameObject bulletP;
	public GameObject baseP;
	public GameObject baseEnterGateP;
	public GameObject baseExitGateP;

	[HideInInspector]
	public GameObject handGunP;
	[HideInInspector]
	public GameObject handGunShotP;

	public GameObject pauseUIG;
	public GameObject ingameUIG;
	public GameObject firstPauseUIG;
	public GameObject inventoryUIG;
	public GameObject mapUIG;
	public GameObject settingUIG;
	public Text aliveTimeT;

	public GameObject BagicUpgraderUIG;
	public GameObject BagicUpgrader_NextUIG;
	public GameObject OxyzenGeneratorUIG;
	public GameObject PurifierUIG;
	public GameObject SterilizerUIG;
	public GameObject SpecialUpgraderUIG;
	public GameObject SpecialUpgrader_NextUIG;
	public GameObject ChestUIG;

	[HideInInspector]
	public GameObject mainPlayer;
	[HideInInspector]
	public GameObject[] mainEnemy;
	[HideInInspector]
	public GameObject mainMapTree;
	[HideInInspector]
	public GameObject[] mainMap;
	[HideInInspector]
	public GameObject[] mainBase;

	void Start () {
		GameManager.gm = this;

		mainPlayer = Instantiate (playerP, new Vector3 (Random.Range (-64.5f, 825), 6, Random.Range (-64.5f, 825)), Quaternion.identity) as GameObject;
		handGunP = GameObject.Find("HandGun");
		handGunShotP = GameObject.Find ("HandGunShot");

		mainMapTree = Instantiate (mainMapTreeP, Vector3.zero, Quaternion.identity) as GameObject;

		mainEnemy = new GameObject[10];
		mainMap = new GameObject[49];
		mainBase = new GameObject[3];

		int num = 0;
		for (int i = 0; i < 7; i++) {
			for(int j = 0; j < 7; j++) {
				mainMap [num] = Instantiate (mapP, new Vector3 (i * 126, 0, j * 126), Quaternion.identity) as GameObject;
				mainMap [num++].transform.parent = mainMapTree.transform;
			}
		}

		for (int i = 0; i < 10; i++)
			mainEnemy [i] = Instantiate (enemyP, new Vector3 (Random.Range (-64.5f, 825), 5, Random.Range (-64.5f, 825)), Quaternion.identity) as GameObject;

		for (int i = 0; i < 3; i++) {
			mainBase [i] = Instantiate (baseP, new Vector3 (Random.Range (0, 755), 3, Random.Range (0, 755)), Quaternion.identity) as GameObject;
			mainBase [i].transform.rotation = Quaternion.Euler (0, 180, 0);
		}
	}

	void Update() {
		totalPlayTime += Time.deltaTime;

		string totalPlayTimea = "" + totalPlayTime.ToString ("00.00");
		totalPlayTimea = totalPlayTimea.Replace (".", ":");
		aliveTimeT.GetComponent<Text> ().text = totalPlayTimea;

		if (Input.GetKey (KeyCode.Escape)) {
			if (pauseUIG.activeSelf == false) {
				pauseUIG.SetActive (true);
			} else {
				pauseUIG.SetActive (false);
			}
		}
	}
}
