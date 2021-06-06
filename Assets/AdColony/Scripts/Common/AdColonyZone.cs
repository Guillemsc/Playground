using System;
using System.Collections;

namespace AdColony
{
    public class Zone
    {
        /// <summary>
        /// Represents the given zone's unique string identifier.
        /// AdColony zone IDs can be created at the [Control Panel](http://clients.adcolony.com).
        /// </summary>
        public string Identifier;

        /// <summary>
        /// Represents the zone type - interstitial, banner, or native.
        /// You can set the type for your zones at the [Control Panel](http://clients.adcolony.com).
        /// NOTE: Unity currently only supports Interstitial ads.
        /// </summary>
        /// <see cref="AdZoneType" />
        public AdZoneType Type;

        /// <summary>
        /// Indicates whether or not the zone is enabled.
        /// Sending invalid zone id strings to `configureWithAppID:zoneIDs:options:completion:` will cause this value to be `NO`.
        /// </summary>
        public bool Enabled;

        /// <summary>
        // Indicates whether or not the zone is configured for rewards.
        // You can configure rewards in your zones at the [Control Panel](http://clients.adcolony.com).
        // Sending invalid zone id strings to `configureWithAppID:zoneIDs:options:completion:` will cause this value to be `NO`.
        /// </summary>
        public bool Rewarded;

        /// <summary>
        /// Represents the number of completed ad views required to receive a reward for the given zone.
        /// This value will be 0 if the given zone is not configured for rewards.
        /// </summary>
        public int ViewsPerReward;

        /// <summary>
        /// Represents the number of ads that must be watched before a reward is given.
        /// This value will be 0 if the given zone is not configured for rewards.
        /// </summary>
        public int ViewsUntilReward;

        /// <summary>
        /// Represents the reward amount for each completed rewarded ad view.
        /// This value will be 0 if the given zone is not configured for rewards.
        /// </summary>
        public int RewardAmount;

        /// <summary>
        /// Represents the singular form of the reward name based on the reward amount.
        /// This value will be an empty string if the given zone is not configured for rewards.
        /// </summary>
        public string RewardName;

        public Zone()
        {
        }

        public Zone(Hashtable values)
        {
            if (values != null)
            {
                if (values.ContainsKey(Constants.ZoneIdentifierKey))
                {
                    Identifier = values[Constants.ZoneIdentifierKey] as string;
                }
                if (values.ContainsKey(Constants.ZoneTypeKey))
                {
                    Type = (AdZoneType)Convert.ToInt32(values[Constants.ZoneTypeKey]);
                }
                if (values.ContainsKey(Constants.ZoneEnabledKey))
                {
                    Enabled = Convert.ToBoolean(Convert.ToInt32(values[Constants.ZoneEnabledKey]));
                }
                if (values.ContainsKey(Constants.ZoneRewardedKey))
                {
                    Rewarded = Convert.ToBoolean(Convert.ToInt32(values[Constants.ZoneRewardedKey]));
                }
                if (values.ContainsKey(Constants.ZoneViewsPerRewardKey))
                {
                    ViewsPerReward = Convert.ToInt32(values[Constants.ZoneViewsPerRewardKey]);
                }
                if (values.ContainsKey(Constants.ZoneViewsUntilRewardKey))
                {
                    ViewsUntilReward = Convert.ToInt32(values[Constants.ZoneViewsUntilRewardKey]);
                }
                if (values.ContainsKey(Constants.ZoneRewardAmountKey))
                {
                    RewardAmount = Convert.ToInt32(values[Constants.ZoneRewardAmountKey]);
                }
                if (values.ContainsKey(Constants.ZoneRewardNameKey))
                {
                    RewardName = values[Constants.ZoneRewardNameKey] as string;
                }
            }
        }

        public string toJsonString()
        {
            Hashtable data = new Hashtable();
            data.Add(Constants.ZoneIdentifierKey, Identifier);
            data.Add(Constants.ZoneTypeKey, Convert.ToInt32(Type).ToString());
            data.Add(Constants.ZoneEnabledKey, Enabled ? "1" : "0");
            data.Add(Constants.ZoneRewardedKey, Rewarded ? "1" : "0");
            data.Add(Constants.ZoneViewsPerRewardKey, ViewsPerReward.ToString());
            data.Add(Constants.ZoneViewsUntilRewardKey, ViewsUntilReward.ToString());
            data.Add(Constants.ZoneRewardAmountKey, RewardAmount.ToString());
            data.Add(Constants.ZoneRewardNameKey, RewardName);

            return AdColonyJson.Encode(data);
        }
    }
}
