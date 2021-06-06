using UnityEngine;
using System.Collections;

namespace AdColony
{
#if UNITY_ANDROID
    public class EventTrackerAndroid : IEventTracker
    {

        //private AndroidJavaClass _plugin;
        private AndroidJavaClass _pluginWrapper;

        public EventTrackerAndroid()
        {
            //_plugin = new AndroidJavaClass("com.adcolony.sdk.AdColonyEventTracker");
            // Separate wrapper to manage type conversions
            _pluginWrapper = new AndroidJavaClass("com.adcolony.unityplugin.UnityADCAds");
        }

        public void LogTransactionWithID(string itemID, int quantity, double price, string currencyCode, string receipt, string store, string description)
        {
            // Need this extra conversion step because the Java interface uses objects for Integer/Double
            _pluginWrapper.CallStatic("logTransactionWithID", itemID, quantity, price, currencyCode, receipt, store, description);
        }

        public void LogCreditsSpentWithName(string name, int quantity, double val, string currencyCode)
        {
            // Need this extra conversion step because the Java interface uses objects for Integer/Double
            _pluginWrapper.CallStatic("logCreditsSpentWithName", name, quantity, val, currencyCode);
        }

        public void LogPaymentInfoAdded()
        {
            _pluginWrapper.CallStatic("logPaymentInfoAdded");
        }

        public void LogAchievementUnlocked(string description)
        {
            _pluginWrapper.CallStatic("logAchievementUnlocked", description);
        }

        public void LogLevelAchieved(int level)
        {
            // Need this extra conversion step because the Java interface uses objects for Integer
            _pluginWrapper.CallStatic("logLevelAchieved", level);
        }

        public void LogAppRated()
        {
            _pluginWrapper.CallStatic("logAppRated");
        }

        public void LogActivated()
        {
            _pluginWrapper.CallStatic("logActivated");
        }

        public void LogTutorialCompleted()
        {
            _pluginWrapper.CallStatic("logTutorialCompleted");
        }

        public void LogSocialSharingEventWithNetwork(string network, string description)
        {
            _pluginWrapper.CallStatic("logSocialSharingEvent", network, description);
        }

        public void LogRegistrationCompletedWithMethod(string method, string description)
        {
            _pluginWrapper.CallStatic("logRegistrationCompleted", method, description);
        }

        public void LogCustomEvent(string eventName, string description)
        {
            _pluginWrapper.CallStatic("logCustomEvent", eventName, description);
        }

        public void LogAddToCartWithID(string itemID)
        {
            _pluginWrapper.CallStatic("logAddToCart", itemID);
        }

        public void LogAddToWishlistWithID(string itemID)
        {
            _pluginWrapper.CallStatic("logAddToWishlist", itemID);
        }

        public void LogCheckoutInitiated()
        {
            _pluginWrapper.CallStatic("logCheckoutInitiated");
        }

        public void LogContentViewWithID(string contentID, string contentType)
        {
            _pluginWrapper.CallStatic("logContentView", contentID, contentType);
        }

        public void LogInvite()
        {
            _pluginWrapper.CallStatic("logInvite");
        }

        public void LogLoginWithMethod(string method)
        {
            _pluginWrapper.CallStatic("logLogin", method);
        }

        public void LogReservation()
        {
            _pluginWrapper.CallStatic("logReservation");
        }

        public void LogSearchWithQuery(string queryString)
        {
            _pluginWrapper.CallStatic("logSearch", queryString);
        }

        public void LogEvent(string name, Hashtable data)
        {
            if (data != null)
            {
                string json = AdColonyJson.Encode(data);
                _pluginWrapper.CallStatic("logEvent", name, json);
            }
            else
            {
                _pluginWrapper.CallStatic("logEvent", name);
            }
        }

        public void LogAdImpression()
        {
            _pluginWrapper.CallStatic("logAdImpression");
        }

        public void LogAppOpen()
        {
            _pluginWrapper.CallStatic("logAppOpen");
        }
    }
#endif
}
