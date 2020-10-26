using Gs2.Core;
using Gs2.Unity;
using Gs2.Unity.Util;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CredentialDirector : MonoBehaviour
{
    [SerializeField]
    CredentialSettings _credentialSettings;

    public Profile profile = null;
    public Client gs2 = null;
    public GameSession gameSession = null;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(RunInitializeSDK());
    }

    IEnumerator RunInitializeSDK()
    {
        Debug.Log("CredentialDirector::RunInitializeSDK::Start");

        profile = new Profile(
            _credentialSettings.applicationCliendId,
            _credentialSettings.applicationClientSecret,
            new Gs2BasicReopener()
        );

        {
            AsyncResult<object> result = null;
            yield return profile.Initialize(
                r => { result = r; }
            );

            if(result.Error != null)
            {
                Debug.Log("CredentialDirector::RunInitializeSDK::クライアントの初期化に失敗しました。");
                yield break;
            }
        }
        gs2 = new Client(profile);
        Debug.Log("CredentialDirector::RunInitializeSDK::OK");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
