﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int diamond = 0;
    public int coin = 0;
    public string user_name = "???";
    public int now_char = 0;
    public bool[] is_char = new bool[8];
    void Start()
    {

    }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
