using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_char : MonoBehaviour
{
    // Start is called before the first frame update
    Text price_t;

    [SerializeField] int price;

    [SerializeField] string nam;

    Sprite image;

    [SerializeField] GameObject buy_obj;

    Buy_check buy_Check;
    void Start()
    {
        buy_Check = buy_obj.GetComponent<Buy_check>();
        price_t = gameObject.transform.Find("Price").GetComponent<Text>();
        price_t.text = price.ToString();
        gameObject.transform.Find("Name").GetComponent<Text>().text = nam;
        image = gameObject.transform.Find("Image").GetComponent<Image>().sprite;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Push_buy(){
        buy_obj.SetActive(true);
        buy_Check.Push_Buycheck(image, price,nam,int.Parse(name));
    }
}
