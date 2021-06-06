using System.Collections;
using System.Runtime.InteropServices;

namespace AdColony
{
#if UNITY_IOS
    public class EventTrackerIOS : IEventTracker
    {
        [DllImport("__Internal")] private static extern void _AdcLogTransactionWithID(string itemID, int quantity, double price, string currencyCode, string receipt, string store, string description);
        [DllImport("__Internal")] private static extern void _AdcLogCreditsSpentWithName(string name, int quantity, double value, string currencyCode);
        [DllImport("__Internal")] private static extern void _AdcLogPaymentInfoAdded();
        [DllImport("__Internal")] private static extern void _AdcLogAchievementUnlocked(string description);
        [DllImport("__Internal")] private static extern void _AdcLogLevelAchieved(int level);
        [DllImport("__Internal")] private static extern void _AdcLogAppRated();
        [DllImport("__Internal")] private static extern void _AdcLogActivated();
        [DllImport("__Internal")] private static extern void _AdcLogTutorialCompleted();
        [DllImport("__Internal")] private static extern void _AdcLogSocialSharingEventWithNetwork(string network, string description);
        [DllImport("__Internal")] private static extern void _AdcLogRegistrationCompletedWithMethod(string method, string description);
        [DllImport("__Internal")] private static extern void _AdcLogCustomEvent(string eventName, string description);
        [DllImport("__Internal")] private static extern void _AdcLogAddToCartWithID(string itemID);
        [DllImport("__Internal")] private static extern void _AdcLogAddToWishlistWithID(string itemID);
        [DllImport("__Internal")] private static extern void _AdcLogCheckoutInitiated();
        [DllImport("__Internal")] private static extern void _AdcLogContentViewWithID(string contentID, string contentType);
        [DllImport("__Internal")] private static extern void _AdcLogInvite();
        [DllImport("__Internal")] private static extern void _AdcLogLoginWithMethod(string method);
        [DllImport("__Internal")] private static extern void _AdcLogReservation();
        [DllImport("__Internal")] private static extern void _AdcLogSearchWithQuery(string queryString);
        [DllImport("__Internal")] private static extern void _AdcLogEvent(string name, string dataAsJson);
        [DllImport("__Internal")] private static extern void _AdcLogImpressionn();
        [DllImport("__Internal")] private static extern void _AdcLogOpen();

        public void LogTransactionWithID(string itemID, int quantity, double price, string currencyCode, string receipt, string store, string description)
        {
            _AdcLogTransactionWithID(itemID, quantity, price, currencyCode, receipt, store, description);
        }

        public void LogCreditsSpentWithName(string name, int quantity, double val, string currencyCode)
        {
            _AdcLogCreditsSpentWithName(name, quantity, val, currencyCode);
        }

        public void LogPaymentInfoAdded()
        {
            _AdcLogPaymentInfoAdded();
        }

        public void LogAchievementUnlocked(string description)
        {
            _AdcLogAchievementUnlocked(description);
        }

        public void LogLevelAchieved(int level)
        {
            _AdcLogLevelAchieved(level);
        }

        public void LogAppRated()
        {
            _AdcLogAppRated();
        }

        public void LogActivated()
        {
            _AdcLogActivated();
        }

        public void LogTutorialCompleted()
        {
            _AdcLogTutorialCompleted();
        }

        public void LogSocialSharingEventWithNetwork(string network, string description)
        {
            _AdcLogSocialSharingEventWithNetwork(network, description);
        }

        public void LogRegistrationCompletedWithMethod(string method, string description)
        {
            _AdcLogRegistrationCompletedWithMethod(method, description);
        }

        public void LogCustomEvent(string eventName, string description)
        {
            _AdcLogCustomEvent(eventName, description);
        }

        public void LogAddToCartWithID(string itemID)
        {
            _AdcLogAddToCartWithID(itemID);
        }

        public void LogAddToWishlistWithID(string itemID)
        {
            _AdcLogAddToWishlistWithID(itemID);
        }

        public void LogCheckoutInitiated()
        {
            _AdcLogCheckoutInitiated();
        }

        public void LogContentViewWithID(string contentID, string contentType)
        {
            _AdcLogContentViewWithID(contentID, contentType);
        }

        public void LogInvite()
        {
            _AdcLogInvite();
        }

        public void LogLoginWithMethod(string method)
        {
            _AdcLogLoginWithMethod(method);
        }

        public void LogReservation()
        {
            _AdcLogReservation();
        }

        public void LogSearchWithQuery(string queryString)
        {
            _AdcLogSearchWithQuery(queryString);
        }

        public void LogEvent(string name, Hashtable data)
        {
            string json = "{}";
            if (data != null)
            {
                json = AdColonyJson.Encode(data);
            }
            _AdcLogEvent(name, json);
        }

        public void LogAdImpression()
        {
            _AdcLogImpressionn();
        }

        public void LogAppOpen()
        {
            _AdcLogOpen();
        }
    }
#endif
}
