using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Facebook.Unity;

public class FacebookAdapter : AnalyticsAdapter {
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // If already initialized, send an app activation Event
            FB.ActivateApp();
        }
    }

    // Send a parameterless event through Facebook Analytics
    public override void sendSimpleEvent(string eventName) {
        FB.LogAppEvent(eventName);
    }

    // Send an event with a parameter through Facebook Analytics
    public override void sendEventWithParam(string eventName, string paramName, object paramValue) {
        var eventParam = new Dictionary<string, object>();
        eventParam[paramName] = paramValue.ToString();
        FB.LogAppEvent(eventName, null, eventParam);
    }

    // Send an event with a parameter and a value through Facebook Analytics
    public override void sendEventWithParamAndValue(string eventName, string paramName, object paramValue, int eventValue) {
        var eventParam = new Dictionary<string, object>();
        eventParam[paramName] = paramValue.ToString();
        FB.LogAppEvent(eventName, eventValue, eventParam);
    }


    // Facebook analytics callback relative to the initialization of the sdk
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // send an app activation Event
            FB.ActivateApp();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    // Facebook analytics callback relative to the initialization of the sdk
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
}
