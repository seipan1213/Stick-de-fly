﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_ground : MonoBehaviour
{
    Player_controll player_Con;
    private void Update() {
        while (!player_Con){
            player_Con = gameObject.transform.root.GetComponent<Player_controll>();
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "ground"){
            player_Con.char_now.Reset_jump();
            player_Con.is_ground = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ground"){
            player_Con.is_ground = false;
        }
    }
}
