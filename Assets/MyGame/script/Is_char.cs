using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_char : MonoBehaviour
{
    DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (!dataManager){
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
            if (!dataManager.is_char[int.Parse(name)]){
                this.gameObject.SetActive(false);
            }
        }
    }
}
