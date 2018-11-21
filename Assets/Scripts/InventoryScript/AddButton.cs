using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Button>().onClick.AddListener(onClick);
    }
    void onClick()
    {
        GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().addOne("Meat");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
