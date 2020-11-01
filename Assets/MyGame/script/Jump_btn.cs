using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump_btn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = this.GetComponent<Button>();
        button.onClick.AddListener(() => {gm.player.GetComponent<Player_controll>().Player_jump();});
    }

    // Update is called once per frame
    void Update()
    {

    }
}
