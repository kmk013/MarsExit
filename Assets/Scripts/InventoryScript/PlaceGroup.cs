using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlaceGroup : MonoBehaviour
{
	public static PlaceGroup instance;
    public int mode = 0;
    public string nowFocus;
    List<string> strs = new List<string> { };

    public void unFocusAll() {
        if (mode == 0) {
            foreach (Transform child in transform)
            {
                child.GetComponent<Place>().isfoucused = false;
            }
            foreach (Transform child in GameObject.Find("placeGroupM2").transform)
            {
                child.GetComponent<Place>().isfoucused = false;
            }
        }
        if (mode == 1) {
            foreach (Transform child in transform)
            {
                child.GetComponent<Place>().isfoucused = false;
            }
            foreach (Transform child in GameObject.Find("placeGroupM").transform)
            {
                child.GetComponent<Place>().isfoucused = false;
            }
        }
    }

    public void init(List<Sprite> sprs)
    {
        int cnt=0;
        Sprite noneImg = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\Disable");

        var result = sprs.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
        foreach (KeyValuePair<Sprite, int> kv in result)
        {
            if (transform.childCount > cnt)
            {
                if (kv.Key.name != "Disable") {
                //if (true) { 
                    unFocusAll();
                    transform.GetChild(cnt).GetComponent<Place>().setSpr(kv.Key);
                    transform.GetChild(cnt).GetComponent<Place>().setName(kv.Key.name);
                    transform.GetChild(cnt).GetComponent<Place>().setText(kv.Value.ToString());
                    transform.GetChild(cnt).GetComponent<Place>().removeLis();
                    transform.GetChild(cnt).GetComponent<Place>().addLis();
                }
                else {
                    unFocusAll();
                    transform.GetChild(cnt).GetComponent<Place>().setSpr(noneImg);
                    transform.GetChild(cnt).GetComponent<Place>().setName(kv.Key.name);
                    transform.GetChild(cnt).GetComponent<Place>().setText("");
                    transform.GetChild(cnt).GetComponent<Place>().removeLis();
                }
                cnt++;
            }
        }
        for(int i = cnt; i < transform.childCount; i++)
        {
            unFocusAll();
            transform.GetChild(i).GetComponent<Place>().setSpr(noneImg);
            transform.GetChild(i).GetComponent<Place>().setText("");
            transform.GetChild(i).GetComponent<Place>().removeLis();
        }
  
    }

    public void init2(List<Sprite> sprs)
    {
        int cnt = 0;
        Sprite noneImg = Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\Disable");
        foreach (Sprite spr in sprs) {
            if (transform.childCount > cnt)
            {
                if (spr.name != "Disable")
                {
                    //if (true) { 
                    unFocusAll();
                    transform.GetChild(cnt).GetComponent<Place>().setSpr(spr);
                    transform.GetChild(cnt).GetComponent<Place>().setName(spr.name);
                    transform.GetChild(cnt).GetComponent<Place>().setText("");
                    transform.GetChild(cnt).GetComponent<Place>().removeLis();
                    transform.GetChild(cnt).GetComponent<Place>().addLis();
                }
                else
                {
                    unFocusAll();
                    transform.GetChild(cnt).GetComponent<Place>().setSpr(noneImg);
                    transform.GetChild(cnt).GetComponent<Place>().setName(spr.name);
                    transform.GetChild(cnt).GetComponent<Place>().setText("");
                    transform.GetChild(cnt).GetComponent<Place>().removeLis();
                }
                cnt++;
            }
            for (int i = cnt; i < transform.childCount; i++)
            {
                unFocusAll();
                transform.GetChild(i).GetComponent<Place>().setSpr(noneImg);
                transform.GetChild(i).GetComponent<Place>().setText("");
                transform.GetChild(i).GetComponent<Place>().removeLis();
            }

        }
    }

    public void strsInit2(List<string> strings)
    {
        strs = new List<string>(strings);
        List<Sprite> sprs = stringsToSprites(strs);
        init2(sprs);
    }

    List<Sprite> stringsToSprites(List<string> strs)
    {
        List<Sprite> sprs = new List<Sprite>();
        foreach (string str in strs)
        {
            sprs.Add(Resources.Load<Sprite>("IngameUI\\Pause\\Inventory\\Item\\"+str));
        }

        return sprs;
    }

    public List<string> getStrs() {
        return strs;
    }

    public void strsInit(List<string> strings) {
        strs = new List<string>(strings);
        List<Sprite> sprs = stringsToSprites(strs);
        init(sprs);
    }

    public void removeOne(string to) {
        for (int i = (strs.Count - 1); i >= 0; i--)
        {
            if (strs[i] == to)
            {
                strs.RemoveAt(i);
                break;
            }
        }
        strsInit(strs);
    }

    public void replaceOne(string from, string to)
    {

    }

    public void addOne(string to)
    {
        strs.Add(to);
        strsInit(strs);
    }


    void Start()
    {
		PlaceGroup.instance = this;
        List<Sprite> sprs = stringsToSprites(strs);
		init(sprs);
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

		foreach (string str in GameManager.gm.dropQ) {
			addOne (str);
		}
        
    }
}