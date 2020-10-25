using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump : MonoBehaviour
{
    GameManager gm;
    float jump_power = 15f;
    GameObject  player;
    Rigidbody2D player_rid;
    bool        is_hit = false;
    [SerializeField] GameObject jump_point;

    private void Start() {
         gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        if (gm.is_jump){
            player_rid.bodyType = RigidbodyType2D.Dynamic;
            Jump();
            gm.is_jump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player")
        {
            is_hit = true;
            player_rid = other.GetComponent<Rigidbody2D>();
            player_rid.bodyType = RigidbodyType2D.Dynamic;
            player = other.gameObject;
            player.transform.position = jump_point.transform.position;
            player.transform.position += new Vector3(0,2,0);
            gm.Push_start();
        }
    }

    void Jump(){
        float rad = gm.angle * Mathf.Deg2Rad;
        Debug.Log(gm.angle);
        Debug.Log(rad);
        float add_x = Mathf.Sin(rad);
        float add_y = Mathf.Cos(rad);
        player_rid.AddForce(new Vector2(add_x,add_y) * gm.power * jump_power);
    }
}
