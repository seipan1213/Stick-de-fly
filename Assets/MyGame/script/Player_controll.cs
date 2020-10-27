using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rig;
    float speed = 3f;
    float jump  = 5.8f;

    public bool is_ground = false;
    public int jump_point = 2;
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rig.velocity.x < 0.1f)
            this.gameObject.transform.Translate(Vector3.right * speed / 60);
    }

    public void Player_jump(){
        Debug.Log("jump");
        if (jump_point > 0){
            rig.velocity = new Vector3(rig.velocity.x,0,0);
            rig.AddForce(Vector3.up * jump * 100);
            jump_point--;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "item"){
            Destroy(other.gameObject);
            speed *= 1.1f;
        }
    }
}
