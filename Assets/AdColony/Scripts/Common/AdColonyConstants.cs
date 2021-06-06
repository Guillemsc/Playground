namespace AdColony
{
    public class Constants
    {
        // JSON keys for general Options
        public static string OptionsMetadataKey = "metadata";

        // JSON keys for AppOptions
        public static string AppOptionsDisableLoggingKey = "logging";
        public static string AppOptionsUserIdKey = "user_id";
        public static string AppOptionsOrientationKey = "orientation";
        public static string AppOptionsTestModeKey = "test_mode";
        public static string AppOptionsGdprRequiredKey = "gdpr_required";
        public static string AppOptionsGdprConsentStringKey = "consent_string";
        // Android only keys:
        public static string AppOptionsMultiWindowEnabledKey = "multi_window_enabled";
        public static string AppOptionsOriginStoreKey = "origin_store";

        // JSON keys for AdOptions
        public static string AdOptionsPrePopupKey = "pre_popup";
        public static string AdOptionsPostPopupKey = "post_popup";

        // JSON keys for UserMetadata
        public static string UserMetadataAgeKey = "age";
        public static string UserMetadataInterestsKey = "interests";
        public static string UserMetadataGenderKey = "gender";
        public static string UserMetadataLatitudeKey = "latitude";
        public static string UserMetadataLongitudeKey = "longitude";
        public static string UserMetadataZipCodeKey = "zipcode";
        public static string UserMetadataHouseholdIncomeKey = "income";
        public static string UserMetadataMaritalStatusKey = "marital_status";
        public static string UserMetadataEducationLevelKey = "edu_level";

        // JSON keys for Zone
        public static string ZoneIdentifierKey = "zone_id";
        public static string ZoneTypeKey = "type";
        public static string ZoneEnabledKey = "enabled";
        public static string ZoneRewardedKey = "rewarded";
        public static string ZoneViewsPerRewardKey = "views_per_reward";
        public static string ZoneViewsUntilRewardKey = "views_until_reward";
        public static string ZoneRewardAmountKey = "reward_amount";
        public static string ZoneRewardNameKey = "reward_name";

        // JSON keys for IAP Opportunity
        public static string OnIAPOpportunityAdKey = "ad";
        public static string OnIAPOpportunityEngagementKey = "engagement";
        public static string OnIAPOpportunityIapProductIdKey = "iap_product_id";

        // JSON keys for currency reward
        public static string OnRewardGrantedZoneIdKey = "zone_id";
        public static string OnRewardGrantedSuccessKey = "success";
        public static string OnRewardGrantedNameKey = "name";
        public static string OnRewardGrantedAmountKey = "amount";

        // JSON keys for custom message
        public static string OnCustomMessageReceivedTypeKey = "type";
        public static string OnCustomMessageReceivedMessageKey = "message";

        public static string AdsManagerName = "AdColony";
        public static string AdsMessageNotInitialized = "AdColony SDK not initialized, use Configure()";
        public static string AdsMessageAlreadyInitialized = "AdColony SDK already initialized";
        public static string AdsMessageSDKUnavailable = "AdColony SDK unavailable on current platform";

        public static string AdsMessageErrorNullAd = "Error, ad is null";
        public static string AdsMessageErrorUnableToRebuildAd = "Error, unable to rebuild ad";
        public static string AdsMessageErrorInvalidImplementation = "Error, platform-specific implementation not set";

        public static string CONSENT_STRING = "_adc_consent_string";
        public static string CONSENT_REQUIRED = "_adc_required";

        public const string AdapterVersion = "4.6.0";
        public const string AndroidSDKVersion = "4.5.0";
        public const string iOSSDKVersion = "4.6.0";
    }

    public class PIEConstants
    {
        /// Constants for PIE (Post-Install Events)
        public static string ADCEventTransaction = "transaction";
        public static string ADCEventCreditsSpent = "credits_spent";
        public static string ADCEventPaymentInfoAdded = "payment_info_added";
        public static string ADCEventAchievementUnlocked = "achievement_unlocked";
        public static string ADCEventLevelAchieved = "level_achieved";
        public static string ADCEventAppRated = "app_rated";
        public static string ADCEventActivated = "activated";
        public static string ADCEventTutorialCompleted = "tutorial_completed";
        public static string ADCEventSocialSharingEvent = "social_sharing_event";
        public static string ADCEventRegistrationCompleted = "registration_completed";
        public static string ADCEventCustomEvent = "custom_event";
        public static string ADCEventAddToCart = "add_to_cart";
        public static string ADCEventAddToWishlist = "add_to_wishlist";
        public static string ADCEventCheckoutInitiated = "checkout_initiated";
        public static string ADCEventContentView = "content_view";
        public static string ADCEventInvite = "invite";
        public static string ADCEventLogin = "login";
        public static string ADCEventReservation = "reservation";
        public static string ADCEventSearch = "search";
        public static string ADCEventAdImpression = "ad_impression";
        public static string ADCEventAppOpen = "app_open";

        /// Post Install Custom Event Slots
        public static string ADCCustomEventSlot1 = "ADCT_CUSTOM_EVENT_1";
        public static string ADCCustomEventSlot2 = "ADCT_CUSTOM_EVENT_2";
        public static string ADCCustomEventSlot3 = "ADCT_CUSTOM_EVENT_3";
        public static string ADCCustomEventSlot4 = "ADCT_CUSTOM_EVENT_4";
        public static string ADCCustomEventSlot5 = "ADCT_CUSTOM_EVENT_5";

        /// Post Install Registration Completed Methods
        public static string ADCRegistrationMethodDefault = "ADCT_DEFAULT_REGISTRATION";
        public static string ADCRegistrationMethodFacebook = "ADCT_FACEBOOK_REGISTRATION";
        public static string ADCRegistrationMethodTwitter = "ADCT_TWITTER_REGISTRATION";
        public static string ADCRegistrationMethodGoogle = "ADCT_GOOGLE_REGISTRATION";
        public static string ADCRegistrationMethodLinkedIn = "ADCT_LINKEDIN_REGISTRATION";
        public static string ADCRegistrationMethodOpenID = "ADCT_OPENID_REGISTRATION";
        public static string ADCRegistrationMethodCustom = "ADCT_CUSTOM_REGISTRATION";

        /// Post Install Login Methods
        public static string ADCLoginMethodDefault = "ADCT_DEFAULT_LOGIN";
        public static string ADCLoginMethodFacebook = "ADCT_FACEBOOK_LOGIN";
        public static string ADCLoginMethodTwitter = "ADCT_TWITTER_LOGIN";
        public static string ADCLoginMethodGoogle = "ADCT_GOOGLE_LOGIN";
        public static string ADCLoginMethodLinkedIn = "ADCT_LINKEDIN_LOGIN";
        public static string ADCLoginMethodOpenID = "ADCT_OPENID_LOGIN";
        public static string ADCLoginMethodCustom = "ADCT_CUSTOM_LOGIN";

        /// Post Install Social Sharing Methods
        public static string ADCSocialSharingMethodFacebook = "ADCT_FACEBOOK_SHARING";
        public static string ADCSocialSharingMethodTwitter = "ADCT_TWITTER_SHARING";
        public static string ADCSocialSharingMethodGoogle = "ADCT_GOOGLE_SHARING";
        public static string ADCSocialSharingMethodLinkedin = "ADCT_LINKEDIN_SHARING";
        public static string ADCSocialSharingMethodPinterest = "ADCT_PINTEREST_SHARING";
        public static string ADCSocialSharingMethodYoutube = "ADCT_YOUTUBE_SHARING";
        public static string ADCSocialSharingMethodInstagram = "ADCT_INSTAGRAM_SHARING";
        public static string ADCSocialSharingMethodTumblr = "ADCT_TUMBLR_SHARING";
        public static string ADCSocialSharingMethodFlickr = "ADCT_FLICKR_SHARING";
        public static string ADCSocialSharingMethodVimeo = "ADCT_VIMEO_SHARING";
        public static string ADCSocialSharingMethodFoursquare = "ADCT_FOURSQUARE_SHARING";
        public static string ADCSocialSharingMethodVine = "ADCT_VINE_SHARING";
        public static string ADCSocialSharingMethodSnapchat = "ADCT_SNAPCHAT_SHARING";
        public static string ADCSocialSharingMethodCustom = "ADCT_CUSTOM_SHARING";
    }
}
