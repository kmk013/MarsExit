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
        string sprName = this.GetComponent<Image>().sprite.name;
        List<string> pastStrs = GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().getStrs();
        string name = GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().nowFocus;
        if (sprName == "Equip")
        {//"Spacesuit", "Bag" , "HandGun", "Disable" 
            if (name == "Spacesuit")
                pastStrs[0] = "Spacesuit";
            if (name == "Bag")
                pastStrs[1] = "Bag";
            if (name == "HandGun")
                pastStrs[2] = "HandGun";
            if (name == "Pickax")
                pastStrs[3] = "Pickax";

            GameObject.Find("placeGroupM2").GetComponent<PlaceGroup>().strsInit2(pastStrs);
            GameObject.Find("placeGroupM").GetComponent<PlaceGroup>().removeOne(name);

            GameObject.Find("Tooltip_ALL").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
