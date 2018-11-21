using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlaceGroup : MonoBehaviour
{
    public Transform nowFocus;
    List<string> strs = new List<string> { };
    public void unFocusAll() {
        foreach (Transform child in transform)
        {
            child.GetComponent<Place>().isfoucused = false;
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
                unFocusAll();
                transform.GetChild(cnt).GetComponent<Place>().setSpr(kv.Key);
                transform.GetChild(cnt).GetComponent<Place>().setName(kv.Key.name);
                transform.GetChild(cnt).GetComponent<Place>().setText(kv.Value.ToString());
                transform.GetChild(cnt).GetComponent<Place>().removeLis();
                transform.GetChild(cnt).GetComponent<Place>().addLis();
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
        strs = strings;
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

    public void addOne(string to)
    {
        strs.Add(to);
        strsInit(strs);
    }


    void Start()
    {
        List<Sprite> sprs = stringsToSprites(strs);
        init(sprs);
    }
}