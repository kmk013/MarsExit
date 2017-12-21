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
        string sprName = this.GetComponent<Image>().sprite.name;
        if (sprName == "UISprite" || sprName == "Eat" || sprName == "Drink") {
            string txt = transform.parent.GetChild(0).GetChild(0).GetComponent<Text>().text;
            GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().removeOne(txt);       
        }
        if (sprName == "Disarming") {
            string name = GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().nowFocus;
            //GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().replaceOne(name,"Disable");

            List<string> pastStrs = GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().getStrs();
            int i  = pastStrs.IndexOf(name);
            Debug.Log(i);
            if (i != -1) pastStrs[i] = "Disable";
            GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().strsInit2(pastStrs);
            GameObject.Find("Tooltip_ALL").SetActive(false);
            
            GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().addOne(name);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
