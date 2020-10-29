using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public RuntimeAnimatorController run_anim;
    public float speed;

    public float weight;
    public float jump;
    public float jump_point_max;
    public float jump_point;

    public float item_power;

    public float jump_min = 4;
    public float speed_min = 2;

    public float weight_min = 1;

    public float jump_point_max_min = 0;

    Character(){
        jump_point = jump_point_max;
    }
    public void Reset_jump(){
        jump_point = jump_point_max;
    }
}