using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameAnalyticsSDK;
using Facebook.Unity;

public class AnalyticsScript : MonoBehaviour {
    // Buttons
    public Button eventParamLessButton;
    public Button eventWithParamButton;
    public Button eventWithParamAndValueButton;

    // List of Analytics tools adapters
    public List<AnalyticsAdapter> analyticsTools;

    void Awake() {
        analyticsTools = new List<AnalyticsAdapter>();
    }

    void OnEnable()
    {
        // Listener button, hardcoded events
        eventParamLessButton.onClick.AddListener(() => sendSimpleEvent("Event_parameterless"));
        eventWithParamButton.onClick.AddListener(() => sendEventWithParam("Event_params", "valeur", 42));
        eventWithParamAndValueButton.onClick.AddListener(() => sendEventWithParamAndValue("Event_full", "nom", "toto", 12));
    }

    // Method logging a parameterless event on all the subscribed adapters
    void sendSimpleEvent(string eventName) {
        foreach (AnalyticsAdapter s in analyticsTools) {
            s.sendSimpleEvent(eventName);
        }
    }

    // Method logging an event with parameter on all the subscribed adapters
    void sendEventWithParam(string eventName, string paramName, object paramValue) {
        foreach (AnalyticsAdapter s in analyticsTools) {
            s.sendEventWithParam(eventName, paramName, paramValue);
        }
    }

    // Method logging an event with parameter and a value on all the subscribed adapters
    void sendEventWithParamAndValue(string eventName, string paramName, object paramValue, int eventValue) {
        foreach (AnalyticsAdapter s in analyticsTools) {
            s.sendEventWithParamAndValue(eventName, paramName, paramValue, eventValue);
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        eventParamLessButton.onClick.RemoveAllListeners();
        eventWithParamButton.onClick.RemoveAllListeners();
        eventWithParamAndValueButton.onClick.RemoveAllListeners();
    }
}
