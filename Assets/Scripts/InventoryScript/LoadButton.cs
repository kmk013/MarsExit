using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(onClick);
    }
    void onClick() {
        List<string> strings = new List<string> { "Water", "Meat", "Water", "Water", "Water", "Water" ,"Cristal"};
        GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().strsInit(strings);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
