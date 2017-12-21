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
        List<string> strings = new List<string> {
            "Water", "Water", "Water", "Water", "Water" , "Water", "Water", "Water", "Water", "Water" ,
            "EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube","EnergyCube",
            "Meat","Meat","Meat","Meat","Meat",
            "FoodCan","FoodCan","FoodCan","FoodCan","FoodCan",
            "Cristal","Cristal","Cristal","Cristal","Cristal"
             };
        GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().strsInit(strings);


        List<string> strings2 = new List<string> { "Spacesuit", "Bag" , "HandGun", "Disable" };
        GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().strsInit2(strings2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
