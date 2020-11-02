using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] public GameObject Shop_window;
    [SerializeField] public GameObject Charcter_window;

    public GameObject[] char_item;
    public GameObject[] diamond;

    Canvas canvas;

    public GameObject[] characters;
    [SerializeField] Text    dia_t;
    [SerializeField] Text    coin_t;
    [SerializeField] Text    user_name_t;

    [SerializeField] GameObject data_go;

    public DataManager dataManager;

    public RewardedAdsScript rewardADS;

    void Start()
    {
        rewardADS = this.GetComponent<RewardedAdsScript>();
        if (!GameObject.Find("DataManager"))
            Instantiate(data_go).name = "DataManager";
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        char_item = GameObject.FindGameObjectsWithTag("char_item");
        diamond = GameObject.FindGameObjectsWithTag("diamond");
        characters = GameObject.FindGameObjectsWithTag("characters");
        Shop_window.SetActive(false);
        Charcter_window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dia_t.text = dataManager.diamond.ToString();
        coin_t.text = dataManager.coin.ToString();
        user_name_t.text = dataManager.user_name;
    }

    public void Push_1P(){
        SceneManager.LoadScene("main");
    }
    public void Push_2P(){

    }
    public void Push_Options(){

    }

    public void Push_Ads(){
        if (dataManager.adv <= 0)
            rewardADS.ShowRewardedVideo("");
    }

    public void Push_Shop(){
        Shop_window.SetActive(true);
        foreach (var item in char_item)
            item.SetActive(true);
        foreach (var item in diamond)
            item.SetActive(false);
    }
    public void Close_Shop(){
        Shop_window.SetActive(false);
    }

    public void Push_Characters(){
        Charcter_window.SetActive(true);
    }
    public void Close_Character(){
        Charcter_window.SetActive(false);
    }
    public void Push_char(){
        foreach (var item in char_item)
            item.SetActive(true);
        foreach (var item in diamond)
            item.SetActive(false);
    }
    public void Push_diamond(){
        foreach (var item in char_item)
            item.SetActive(false);
        foreach (var item in diamond)
            item.SetActive(true);
    }
}
