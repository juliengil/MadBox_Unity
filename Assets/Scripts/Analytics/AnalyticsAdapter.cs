using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class describing the methods to implement in its inherited classes
public abstract class AnalyticsAdapter : MonoBehaviour {
    public virtual void Start() {
        // Add the current adapter to the analytics script
        GetComponent<AnalyticsScript>().analyticsTools.Add(this);
    }

    public abstract void sendSimpleEvent(string eventName);
    public abstract void sendEventWithParam(string eventName, string paramName, object paramValue);
    public abstract void sendEventWithParamAndValue(string eventName, string paramName, object paramValue, int eventValue);
}
