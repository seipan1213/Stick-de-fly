﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class RewardedAdsScript : MonoBehaviour, IUnityAdsListener {
    string gameId = "3886047";
    string myPlacementId = "rewardedVideo";
    bool testMode = true;
    public string scene = "main";
    DataManager dm;

    // Initialize the Ads listener and service:
    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }

    public void ShowRewardedVideo(string s_name) {
        scene = s_name;
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId)) {
            Advertisement.Show(myPlacementId);
        }
        else {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            if (scene != ""){
                SceneManager.LoadScene(scene);
            }else{
                dm = GameObject.Find("DataManager").GetComponent<DataManager>();
                dm.diamond += 2;
                dm.adv = dm.movie_time;
            }
            // Reward the user for watching the ad to completion.
        } else if (showResult == ShowResult.Skipped) {
            Debug.Log(ShowResult.Skipped);
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.Log(ShowResult.Failed);
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId) {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }
}
