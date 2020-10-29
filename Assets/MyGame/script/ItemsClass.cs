using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int speed;
	public int weight;
	public int jump;
	public int jump_point;
	public void Attach(Player_controll player_con)
	{
		player_con.char_now.speed += speed * player_con.char_now.item_power;
		player_con.char_now.weight += weight * player_con.char_now.item_power;
		player_con.char_now.jump += jump * player_con.char_now.item_power;
		player_con.char_now.jump_point_max += jump_point * player_con.char_now.item_power;

        if (player_con.char_now.speed < player_con.char_now.speed_min)
            player_con.char_now.speed = player_con.char_now.speed_min;

        if (player_con.char_now.weight < player_con.char_now.weight_min)
            player_con.char_now.weight = player_con.char_now.weight_min;

        if (player_con.char_now.jump < player_con.char_now.jump_min)
            player_con.char_now.jump = player_con.char_now.jump_min;

        if (player_con.char_now.jump_point_max < player_con.char_now.jump_point_max_min)
            player_con.char_now.jump_point_max = player_con.char_now.jump_point_max_min;
	}
}
