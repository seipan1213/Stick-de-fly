using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_active : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] chars;
    void Start()
    {
        chars = GameObject.FindGameObjectsWithTag("characters");
    }

    private void OnEnable() {
        foreach(var ch in chars){
            ch.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
