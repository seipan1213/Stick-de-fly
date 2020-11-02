using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public float power = 0f;
    public float angle = 0f;
    float power_speed = 0.3f;
    float angel_speed = 0.9f;
    float jump_score = 0;
    float max_angle = 358f;
    float min_angle = 270f;
    float ch_rotate;
    bool is_power = false;
    bool is_angle = false;
    public bool is_jump = false;

    public float start_x = 0;
    public float distance;
    UIManager um;
    public GameObject player;
    Tilemap_generate tilemap_gene;
    float gene_point = 0;
    public bool is_gameover = false;
    public bool is_start = false;
    [SerializeField] CinemachineVirtualCamera vc;
    public RewardedAdsScript rewardADS;
    public DataManager dataManager;
    public Transform Player_res;
    [SerializeField] GameObject data_go;
    [SerializeField] public GameObject[] chars = new GameObject[8];
    void Start()
    {
        if (!GameObject.Find("DataManager"))
            Instantiate(data_go).name = "DataManager";
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        um = GameObject.Find("UIManager").GetComponent<UIManager>();
        rewardADS = this.GetComponent<RewardedAdsScript>();
        Debug.Log(dataManager.now_char);
        Instantiate(chars[dataManager.now_char],Player_res.position,Player_res.rotation);
        player = GameObject.FindWithTag("Player");
        vc.Follow = player.transform;
        vc.LookAt = player.transform;
        tilemap_gene = this.GetComponent<Tilemap_generate>();
        tilemap_gene.Map_generator(1500, 6, 3);
        Time.timeScale = 1;
        vc.m_Lens.OrthographicSize = 6;
    }

    void FixedUpdate()
    {
        if (is_power){
            Move_power_gage();
        }
        if (is_angle){
            Move_angle();
        }
        if (start_x != 0)
            distance = player.transform.position.x - start_x;
        if (is_gameover){
            um.Gameover_UI();
            Time.timeScale = 0;
        }
        if (is_start){
            vc.m_Lens.OrthographicSize = 6;
        }
    }

    public void Push_start(){
        vc.m_Lens.OrthographicSize = 15;
        is_power = true;
        um.power_btn.SetActive(true);
        um.power_slider.gameObject.SetActive(true);
    }

    public void Push_power(){
        is_power = false;
        var coroutine = Non_power();
        StartCoroutine(coroutine);
    }
    public void Push_angle(){
        is_angle = false;
        var coroutine = Non_angle();
        StartCoroutine(coroutine);
    }

    private void Move_power_gage(){
        um.power_slider.value = power / 100;
        power += (power_speed + (Mathf.Abs(power / 5) * power_speed));
        if ((power >= 100 && power_speed > 0) || (power <= 0 && power_speed < 0)){
            power_speed *= -1;
        }
    }

    private void Move_angle(){
        if (min_angle >= um.angel_img.rectTransform.eulerAngles.z){
            ch_rotate = angel_speed;
        }
        if (max_angle <= um.angel_img.rectTransform.eulerAngles.z){
            ch_rotate = -angel_speed;
        }
        um.angel_img.rectTransform.Rotate(0, 0, ch_rotate);
    }
    IEnumerator Non_power()
    {
        um.power_btn.SetActive(false);
        yield return new WaitForSeconds(1f);
        um.power_slider.gameObject.SetActive(false);
        ch_rotate = angel_speed;
        is_angle = true;
        um.angle_btn.SetActive(true);
        um.angel_img.gameObject.SetActive(true);
    }
    IEnumerator Non_angle()
    {
        um.angle_btn.SetActive(false);
        yield return new WaitForSeconds(1f);
        angle = Mathf.Abs(360 - um.angel_img.rectTransform.eulerAngles.z);
        um.angel_img.gameObject.SetActive(false);
        is_jump = true;
        start_x = player.transform.position.x;
        um.score.gameObject.SetActive(true);
        um.jump_btn.SetActive(true);
    }
    public void Retry_load(){
        rewardADS.ShowRewardedVideo("main");
    }
    public void Title_load(){
        rewardADS.ShowRewardedVideo("title");
    }
}
