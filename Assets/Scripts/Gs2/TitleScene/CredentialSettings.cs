using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredentialSettings : MonoBehaviour
{
    //バックエンドサーバに接続するための識別子
    [SerializeField]
    public string applicationCliendId;
    [SerializeField]
    public string applicationClientSecret;
}
