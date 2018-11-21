using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(onClick);
    }
    void onClick()
    {
        GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().removeOne("Meat");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
