#pragma once

// JSON keys for AdColonyOptions
#define ADC_OPTIONS_METADATA_KEY @"metadata"

// JSON keys for AdColonyAppOptions
#define ADC_APPOPTIONS_DISABLE_LOGGING_KEY @"logging"
#define ADC_APPOPTIONS_USER_ID_KEY @"user_id"
#define ADC_APPOPTIONS_ORIENTATION @"orientation"
#define ADC_APPOPTIONS_GDPR_REQUIRED @"gdpr_required"
#define ADC_APPOPTIONS_GDPR_CONSENT_STRING @"consent_string"

// JSON keys for AdColonyAdOptions
#define ADC_ADOPTIONS_PRE_POPUP_KEY @"pre_popup"
#define ADC_ADOPTIONS_POST_POPUP_KEY @"post_popup"

// JSON keys for AdColonyZone
#define ADC_ZONE_IDENTIFIER_KEY @"zone_id"
#define ADC_ZONE_TYPE_KEY @"type"
#define ADC_ZONE_ENABLED_KEY @"enabled"
#define ADC_ZONE_REWARDED_KEY @"rewarded"
#define ADC_ZONE_VIEWS_PER_REWARD_KEY @"views_per_reward"
#define ADC_ZONE_VIEWS_UNTIL_REWARD_KEY @"views_until_reward"
#define ADC_ZONE_REWARD_AMOUNT_KEY @"reward_amount"
#define ADC_ZONE_REWARD_NAME_KEY @"reward_name"

// JSON keys for AdColonyUserMetadata
#define ADC_USER_METADATA_AGE_KEY @"age"
#define ADC_USER_METADATA_INTERESTS_KEY @"interests"
#define ADC_USER_METADATA_GENDER_KEY @"gender"
#define ADC_USER_METADATA_LATITUDE_KEY @"latitude"
#define ADC_USER_METADATA_LONGITUDE_KEY @"longitude"
#define ADC_USER_METADATA_ZIPCODE_KEY @"zipcode"
#define ADC_USER_METADATA_HOUSEHOLD_INCOME_KEY @"income"
#define ADC_USER_METADATA_MARITAL_STATUS_KEY @"marital_status"
#define ADC_USER_METADATA_EDUCATION_LEVEL_KEY @"edu_level"

// Request Interstitial Failed keys
#define ADC_REQUEST_INTERSTITIAL_FAILED_ERROR_CODE_KEY @"error_code"

// IAP Opportunity keys
#define ADC_ON_IAP_OPPORTUNITY_AD_KEY @"ad"
#define ADC_ON_IAP_OPPORTUNITY_ENGAGEMENT_KEY @"engagement"
#define ADC_ON_IAP_OPPORTUNITY_IAP_PRODUCT_ID_KEY @"iap_product_id"

// JSON keys for a currency reward
#define ADC_ON_REWARD_GRANTED_ZONEID_KEY @"zone_id"
#define ADC_ON_REWARD_GRANTED_SUCCESS_KEY @"success"
#define ADC_ON_REWARD_GRANTED_NAME_KEY @"name"
#define ADC_ON_REWARD_GRANTED_AMOUNT_KEY @"amount"

// JSON keys for responding to a custom message
#define ADC_ON_CUSTOM_MESSAGE_RECEIVED_TYPE_KEY @"type"
#define ADC_ON_CUSTOM_MESSAGE_RECEIVED_MESSAGE_KEY @"message"

//Privacy Laws Keys
#define ADC_CONSENT_STRING @"_adc_consent_string"
#define ADC_CONSENT_REQUIRED @"_adc_required"
