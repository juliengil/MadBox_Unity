# MadBox_Unity

### Time spent
 * 4h on the unity UI handling
 * 4h on the Analytics integration and scripts
 * 1h on the ads scripts
 * 6h on the ads integration to try to make them work
 * times are including the seeking of informations, not the tools downloading

### Technical/architectural choices
 * I used a script throwing hardcoded events by calling "adapter" instances, which inherits from an abstract class called AnalyticsAdapter. For each analytic tool we want to integrate to the project we have to create an adapter, with the mandatory methods described in the AnalyticsAdapter. This new adapter makes the interface between the existing code and the new analytic tools being integrated. Every adapter script will have to be added to the canvas component (for instance), so when it will load, the start method will subscribe itself to the code sending events. Anytime we want to send an event, we simply call on the code located in the AnalyticsScript which will delegate it to all the subscribed adapter instances.
 * For the Ads integration, since it doesn't work, I just provide the script to show what I started to do : a simple generic integration of the Unity Ads, which can be reused either for banners, interstitials or rewarded videos.

### The hard parts
 * Getting used to Unity, creating the scenes and the UI : The specific build settings, all the tools related to the game environment and the UI (Canvas, Camera).
 * Getting used to the C# syntax.
 * Building the project on my mobile phone (samsung) which didn't want to be recognized at first, for some reasons.
 * Making the Ads work, I actually couldn't manage to make it work. Didn't get any explicit error or warning about it though. I would be glad if you could enlight me about it... I tried to install it twice through the Asset Store, and twice through the package manager, created a new project, reinstalled unity... Some of the thread I went through : [curl error](https://forum.unity.com/threads/whats-curl-error-56.794703/), [ads crash](https://forum.unity.com/threads/ads-crash-on-android.802656/), [other ads crash](https://forum.unity.com/threads/game-crash-on-android-after-integrating-unity-ads.611131/)

### Next steps
 * Extract the tracking logic into the cloud, in a custom tracking API calling on all the desired analytic tools API. So instead of having the same code duplicated over all the games to track, we would simply use the same syntax everywhere, making the code and the games lighter, their data consumption lighter as well, and the maintenance would be done just once, on the server side API.

 OR

 * Using a TMS (tag management system) as GTM (google tag manager) to avoid having to update the analytics code too often. The downside is that GTM does't have ready-to-go connections with all the analytics solutions, so we would still have to write custom code to handle it.