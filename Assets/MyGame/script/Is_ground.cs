using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_ground : MonoBehaviour
{
    Player_controll player_Con;
    void Start()
    {
        player_Con = gameObject.transform.root.GetComponent<Player_controll>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ground"){
            Debug.Log(player_Con.jump_point);
            player_Con.jump_point = 2;
            player_Con.is_ground = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ground"){
            player_Con.jump_point = 1;
            player_Con.is_ground = false;
        }
    }
}
