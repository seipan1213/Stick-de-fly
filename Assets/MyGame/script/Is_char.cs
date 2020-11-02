using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_char : MonoBehaviour
{
    DataManager dataManager;
    GameObject roll;

    GameObject choice;
    // Start is called before the first frame update
    void Start()
    {
        roll = this.gameObject.transform.Find("Roll").gameObject;
        choice = this.gameObject.transform.Find("Choice").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        while (!dataManager){
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        }
        if (!dataManager.is_char[int.Parse(name)]){
            this.gameObject.SetActive(false);
        }
        if (dataManager.now_char != int.Parse(name)){
            roll.SetActive(false);
            choice.SetActive(false);
        }else{
            roll.SetActive(true);
            choice.SetActive(true);
        }
    }

    public void Change_char(){
        dataManager.now_char = int.Parse(name);
    }
}
