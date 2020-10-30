using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleManager : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] public GameObject Shop_window;

    public GameObject[] char_item;
    public GameObject[] diamond;

    Canvas canvas;

    [SerializeField] Text    dia_t;
    [SerializeField] Text    coin_t;
    [SerializeField] Text    user_name_t;

    [SerializeField] GameObject data_go;
    DataManager dataManager;

    void Start()
    {
        if (!GameObject.Find("DataManager"))
            Instantiate(data_go).name = "DataManager";
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        char_item = GameObject.FindGameObjectsWithTag("char_item");
        diamond = GameObject.FindGameObjectsWithTag("diamond");
        Shop_window.SetActive(false);
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
