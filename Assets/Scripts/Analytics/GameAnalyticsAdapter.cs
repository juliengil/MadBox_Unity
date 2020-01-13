using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticsAdapter : AnalyticsAdapter {
    public override void Start()
    {
        base.Start();
        // Initialize GameAnalytics object
        GameAnalytics.Initialize();
    }

    // Send a parameterless event through Game Analytics
    public override void sendSimpleEvent(string eventName) {
        GameAnalytics.NewDesignEvent(eventName);
    }

    // Send an event with a parameter through Game Analytics
    public override void sendEventWithParam(string eventName, string paramName, object paramValue) {
        GameAnalytics.NewDesignEvent(eventName+":"+paramName+":"+paramValue.ToString());
    }

    // Send an event with a parameter and a value through Game Analytics
    public override void sendEventWithParamAndValue(string eventName, string paramName, object paramValue, int eventValue) {
        GameAnalytics.NewDesignEvent(eventName+":"+paramName+":"+paramValue.ToString(), eventValue);
    }
}
