using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_hit : MonoBehaviour
{
    // Start is called before the first frame update

    GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ground"){
            gm.is_gameover = true;
        }
    }
}
