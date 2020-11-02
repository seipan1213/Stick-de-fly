using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buy_check : MonoBehaviour
{
    // Start is called before the first frame update
    Image spr;
    Text pri;
    Text na;

    GameObject OK;
    DataManager dm;
    int is_char;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Push_Buycheck(Sprite spt, int price, string name,int ch)
    {
        dm = GameObject.Find("DataManager").GetComponent<DataManager>();
        spr = this.gameObject.transform.Find("Char").GetComponent<Image>();
        pri = this.gameObject.transform.Find("Price").GetComponent<Text>();
        na = this.gameObject.transform.Find("Name").GetComponent<Text>();
        spr.sprite = spt;
        pri.text = price.ToString();
        na.text = name;
        is_char = ch;
        OK = this.gameObject.transform.Find("OK").gameObject;
        if (dm.coin >= int.Parse(pri.text)){
            OK.SetActive(true);
        }else{
            OK.SetActive(false);
        }
    }

    public void Push_OK(){
        dm.coin -= int.Parse(pri.text);
        this.gameObject.SetActive(false);
    }
    public void Push_NO(){
        this.gameObject.SetActive(false);
    }
}
