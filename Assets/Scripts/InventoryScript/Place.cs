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


    void Update() {
        if (isfoucused)
        {
            setColor(Color.gray);
            GameObject tooltip = GameObject.Find("Inventory_ALL").transform.Find("Tooltip_ALL").gameObject;

            tooltip.SetActive(true);
            if (name == "Cristal" || name == "EnergyCube")
            {
                tooltip.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                tooltip.transform.GetChild(1).gameObject.SetActive(true);
            }
            int mode = this.transform.parent.GetComponent<PlaceGroup>().mode;
            if (mode == 0)
            {
                if (name == "Meat" || name == "FoodCan") tooltip.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\ItemInfoUI\\Eat");
                if (name == "Water") tooltip.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\ItemInfoUI\\Drink");

                if (name == "Spacesuit" || name == "HandGun"|| name == "Bag") tooltip.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\ItemInfoUI\\Equip");
            }
            else {
                tooltip.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\ItemInfoUI\\Disarming");
            }
            if (mode == 0)
            {
                tooltip.transform.position = new Vector3(transform.GetChild(0).position.x - 500, transform.GetChild(0).position.y - 100, transform.GetChild(0).position.z);
                tooltip.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name;
            }
            else
            {
                tooltip.transform.position = new Vector3(transform.GetChild(0).position.x + 70, transform.GetChild(0).position.y - 100, transform.GetChild(0).position.z);
                tooltip.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = name;
            }

        }
        else {

            setColor(Color.white);
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
            transform.parent.GetComponent<PlaceGroup>().nowFocus = name;
            Debug.Log(transform);
            Debug.Log("clicked");
        
    }
}
