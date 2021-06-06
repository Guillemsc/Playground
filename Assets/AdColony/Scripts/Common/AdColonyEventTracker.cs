using System.Collections;

namespace AdColony
{



    public interface IEventTracker
    {
        /// <summary>
        /// Report a transaction/purchase event.
        /// </summary>
        /// Call this method to track any purchases made by the user.
        /// <param name="itemID">Identifier of item purchased</param>
        /// <param name="quantity">Quantity of items purchased</param>
        /// <param name="price">Total price of the items purchased</param>
        /// <param name="currencyCode">The real-world three-letter ISO 4217 (e.g. USD) currency code of the transaction</param>
        /// <param name="store">The store the purchase was made through</param>
        /// <param name="receipt">The receipt number</param>
        /// <param name="description">Description of the purchased product. Max 512 characters.</param>
        void LogTransactionWithID(string itemID, int quantity, double price, string currencyCode, string receipt, string store, string description);

        /// <summary>
        /// Report a credits_spent event.
        /// </summary>
        /// Invoke, for example, when a user applies credits to purchase in app merchandise.
        /// You can also provide additional information about the transaction like the name, quantity, real-world value and currency code
        /// <param name="name">The type of credits the user has spent</param>
        /// <param name="quantity">The quantity of the credits spent</param>
        /// <param name="value">The real-world value of the credits spent</param>
        /// <param name="currencyCode">The real-world three-letter ISO 4217 (e.g. USD) currency code of the transaction.</param>
        void LogCreditsSpentWithName(string name, int quantity, double value, string currencyCode);

        /// <summary>
        /// Report a payment_info_added event, when the user has added payment info for transactions.
        /// </summary>
        void LogPaymentInfoAdded();

        /// <summary>
        /// Report an achievement_unlocked event.
        /// </summary>
        /// Invoke when a user completes some goal, for example, ‘complete 200 deliveries’.
        /// You can also add a description of the achievement
        /// <param name="description">A string description of the in-app achievement. Max 512 characters.</param>
        void LogAchievementUnlocked(string description);

        /// <summary>
        /// Report a level_achieved event.
        /// </summary>
        /// <param name="level">The new level reached by the user</param>
        void LogLevelAchieved(int level);

        /// <summary>
        /// Report an app_rated event.
        /// </summary>
        /// Invoke when the user has rated the application.
        void LogAppRated();

        /// <summary>
        /// Report an activated event.
        /// </summary>
        /// Invoke when the user activates their account within the app.
        void LogActivated();

        /// <summary>
        /// Report a tutorial_completed event.
        /// </summary>
        /// Invoke when the user completes an introductory tutorial for the app.
        void LogTutorialCompleted();

        /// <summary>
        /// Report a social_sharing event.
        /// </summary>
        /// Invoke, for example, when user shares an achievement on Facebook, Twitter, etc.. You can also
        /// provide a description of the social sharing event and denote the network on which the event was shared.
        /// It is recommended to use the provided ADCSocialSharingMethod* constants within PIEConstants.
        /// <param name="network">Associated Social Network.</param>
        /// <param name="description">Description of the social sharing event. Max 512 characters.</param>
        void LogSocialSharingEventWithNetwork(string network, string description);

        /// <summary>
        /// Report a registration_completed event.
        /// </summary>
        /// Invoke when a user has finished the registration process within the app.
        /// You can also denote the registration method used: Facebook, Google, etc.
        /// It is recommended to use the provided ADCRegistrationMethod* constants within PIEConstants.
        /// <param name="method">The registration method used</param>
        /// <param name="description">Description describing the registration event. Passing a nil value is allowed. Should only pass this in if you are passing in ADCRegistrationMethodCustom for the method. Will be ignored otherwise. Max 512 characters</param>
        void LogRegistrationCompletedWithMethod(string method, string description);

        /// <summary>
        /// Report a custom_event.
        /// </summary>
        /// Currently, publishers are allowed up to 5 custom event slots and are required
        /// to keep track of what each corresponds to on their end.
        /// It is recommended to use the provided ADCCustomEvent* constants within PIEConstants.
        /// <param name="eventName">The custom event name</param>
        /// <param name="description">The description of the custom event. Max 512 characters.</param>
        void LogCustomEvent(string eventName, string description);

        /// <summary>
        /// Report an add_to_cart event.
        /// </summary>
        /// Invoke when the user adds an item to a shopping cart. You can also report the product
        /// identifier for the item.
        /// <param name="itemID">Identifier of item added to cart</param>
        void LogAddToCartWithID(string itemID);

        /// <summary>
        /// Report an add_to_wishlist event.
        /// </summary>
        /// Invoke when the user adds an item to their wishlist. You can also report the product
        /// identifier for the item.
        /// <param name="itemID">Identifier of item added to cart</param>
        void LogAddToWishlistWithID(string itemID);

        /// <summary>
        /// Report an checkout_initiated event
        /// </summary>
        /// Invoke when a user has begun the final checkout process.
        void LogCheckoutInitiated();

        /// <summary>
        /// Report a content_view event.
        /// </summary>
        /// Invoke when the user viewed the contents of a purchasable product
        /// <param name="contentId">Identifier of content viewed</param>
        /// <param name="contentType">Type of content viewed</param>
        void LogContentViewWithID(string contentID, string contentType);

        /// <summary>
        /// Report an invite event.
        /// </summary>
        /// Invoke when a user invites friends or family to install or otherwise re-engage in your app or service.
        void LogInvite();

        /// <summary>
        /// Report a login event.
        /// </summary>
        /// Invoke whenever the user has successfully logged in to the app.
        /// It is recommended to use the provided ADCLoginMethod* constants within PIEConstants.
        /// <param name="method">The login method used.</param>
        void LogLoginWithMethod(string method);

        /// <summary>
        /// Report a reservation event.
        /// </summary>
        void LogReservation();

        /// <summary>
        /// Report a search event.
        /// </summary>
        /// <param name="queryString">Search terms, keywords, or queries. As provided by the user.</param>
        void LogSearchWithQuery(string queryString);

        /// <summary>
        /// Log an event.
        /// </summary>
        /// Provided to allow the construction and logging of events that do not have a predefined method within this class.
        /// It is recommended to use the provided ADCEvent* constants within PIEConstants for the event name, build the appropriate data from constants if applicable.
        /// <param name="name">Name of the event</param>
        /// <param name="payload">Event data, including both required and optional meta information.</param>
        void LogEvent(string name, Hashtable data);


        /// <summary>
        /// Log an event when an ad impression has occurred.
        /// </summary>
        void LogAdImpression();

        /// <summary>
        /// Log an event when the app has opened.
        /// </summary>
        void LogAppOpen();    
    }
}
