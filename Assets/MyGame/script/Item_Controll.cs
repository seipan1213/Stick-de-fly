using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controll : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Item item;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player_controll>()){
            item.Attach(other.GetComponent<Player_controll>());
            Destroy(this.gameObject);
        }
    }
}
