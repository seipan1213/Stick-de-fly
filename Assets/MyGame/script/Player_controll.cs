using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System.Text.RegularExpressions;

public class Player_controll : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rig;
    Animator anim;
    int     is_char = 0;
    public bool is_ground = false;
    public int item_point = 0;


    GameManager gm;
    [SerializeField] public Character char_now;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rig = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        anim.runtimeAnimatorController = char_now.run_anim;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rig.velocity.x < 0.1f){
            this.gameObject.transform.Translate(Vector3.right * char_now.speed / 60);
            anim.SetBool("Run",true);
        }
        if (rig.velocity.y < 0){
            anim.SetInteger("Jump", 2);
        }
        else if (rig.velocity.y < 0.1f && rig.velocity.y > -0.1f && is_ground){
            anim.SetInteger("Jump", 0);
        }
        if (is_ground)
            gm.is_start = true;
        if (rig.gravityScale != char_now.weight){
            rig.gravityScale = char_now.weight * 0.85f;
        }
        //if (Input.GetKey(KeyCode.D)){
        //    anim.SetBool("Run",true);
        //}
        //else{
        //    anim.SetBool("Run",false);
        //}
    }

    public void Player_jump(){
        if (char_now.jump_point > 0 || is_ground){
            anim.SetInteger("Jump",1);
            rig.velocity = new Vector3(rig.velocity.x,0,0);
            rig.AddForce(Vector3.up * char_now.jump * 100);
            if (!is_ground)
                char_now.jump_point--;
        }

    }
}