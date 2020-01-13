using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class AdScript : MonoBehaviour, IUnityAdsListener {
    // preprocessor directives to set up the gameId
    #if UNITY_IOS
    private string gameId = "3426028";
    #elif UNITY_ANDROID
    private string gameId = "3426029";
    #endif

    // External requirements
    public string adId;
    public Toggle adToggle;
    public Button adButton;

    void Start()
    {
        // Don't allow interaction with the checkbox, and uncheck it
        adToggle.enabled = false;
        adToggle.isOn = false;

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true, true);
        // Add listener for the button
        adButton.onClick.AddListener(() => displayAd());
    }

    // Simply displays the Unity Ad if it is ready
    private void displayAd() {
        // Only try to display ad if the ad is ready
        if (Advertisement.IsReady(adId)) {
            Advertisement.Show(adId);
        }
    }

    // IUnityAdsListener interface callback method used when an Ad is ready
    public void OnUnityAdsReady(string placementId)
    {
        // check if the ready ad is the one we want to display
        if (placementId == adId) {
            adToggle.isOn = true;
        }
    }

    // IUnityAdsListener interface callback method used when an Ad errors
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    // IUnityAdsListener interface callback method used when an Ad starts
    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad with placement ID \"" + placementId + "\" started.");
    }

    // IUnityAdsListener interface callback method used when an Ad finishes
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Ad with placement ID \"" + placementId + "\" finished.");
    }

    void OnDisable()
    {
        //Un-Register Button Events
        adButton.onClick.RemoveAllListeners();
    }
}