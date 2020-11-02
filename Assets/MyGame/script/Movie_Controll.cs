using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movie_Controll : MonoBehaviour
{
    // Start is called before the first frame update
    DataManager dataManager;
    public Image image;

    Text text;
    void Start()
    {
        image = this.GetComponent<Image>();
        text = GameObject.Find("Retime").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dataManager){
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        }else{
            image.fillAmount = 1 - (dataManager.adv / dataManager.movie_time);
            if ((int)(dataManager.adv) <= 0)
                text.text = "";
            else
                text.text = ((int)(dataManager.adv) / 60).ToString() + "min";
        }
    }
}
