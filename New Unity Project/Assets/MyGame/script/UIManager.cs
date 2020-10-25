using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager gm;
    public GameObject   power_btn;
    public GameObject   angle_btn;

    public Slider       power_slider;
    public Image        angel_img;

    public Text         score;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        power_btn.SetActive(false);
        angle_btn.SetActive(false);
        score.gameObject.SetActive(false);
        power_slider.gameObject.SetActive(false);
        angel_img.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.is_jump)
            score.gameObject.SetActive(true);
        if (score.IsActive())
            score.text = gm.distance.ToString();
    }
}
