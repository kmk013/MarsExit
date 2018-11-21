using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Place : MonoBehaviour {
    public bool isfoucused = false;
    public bool isAble = true;
    string name;

    public bool getIsAble() {
        return isAble;
    }

    public void setColor(Color c) {
        Image i1 = transform.GetChild(0).GetComponent<Image>();
        i1.color = c;
    }
    public void setSpr(Sprite spr)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = spr;
    }

    public void setText(string str) {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = str;
    }
    public void setName(string str)
    {
        name = str;
    }


    void Update () {
		if (isfoucused) {
			setColor (Color.gray);
			GameObject tooltip = GameObject.Find ("Inventory_ALL").transform.Find ("Tooltip_ALL").gameObject;
			if (name == "Cristal") {
				tooltip.SetActive (false);
			} else {
				tooltip.SetActive (true);
				tooltip.transform.position = new Vector3 (transform.GetChild (0).position.x - 500, transform.GetChild (0).position.y - 100, transform.GetChild (0).position.z);
				tooltip.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = name;
			}

		} else {
			setColor (Color.white);
		}
    }

    public void addLis() {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(processClick);
    }
    public void removeLis(){
        transform.GetChild(0).GetComponent<Button>().onClick.RemoveListener(processClick);
    }


    void processClick() {   
            transform.parent.GetComponent<PlaceGroup>().unFocusAll();
            isfoucused = true;
            transform.parent.GetComponent<PlaceGroup>().nowFocus = transform;
            Debug.Log(transform);
            Debug.Log("clicked");
        
    }
}
