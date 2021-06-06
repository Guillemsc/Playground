using System;
using System.Collections;
using UnityEngine;

namespace AdColony
{

    public class InterstitialAd
    {
        /// <summary>
        /// Represents the unique zone identifier string from which the interstitial was requested.
        /// AdColony zone IDs can be created at the [Control Panel](http://clients.adcolony.com).
        /// </summary>
        public string ZoneId;

        /// <summary>
        /// Indicates whether or not the interstitial has been played or if it has met its expiration time.
        /// AdColony interstitials become expired as soon as the ad launches or just before they have met their expiration time.
        /// </summary>
        public bool Expired;

        // ---------------------------------------------------------------------------

        #region Internal Methods - do not call these
        public string Id;

        public InterstitialAd(Hashtable values)
        {
            UpdateValues(values);
        }

        public void UpdateValues(Hashtable values)
        {
            if (values != null)
            {
                if (values.ContainsKey("zone_id"))
                {
                    ZoneId = values["zone_id"] as string;
                }
                if (values.ContainsKey("expired"))
                {
                    Expired = Convert.ToBoolean(values["expired"]);
                }
                if (values.ContainsKey("id"))
                {
                    Id = values["id"] as string;
                }
            }
        }

        ~InterstitialAd()
        {
            Debug.Log("AdColony.InterstitialAd.Destructors called.");
            if (IsValid())
            {
                Ads.SharedGameObject.EnqueueAction(() => { Ads.DestroyAd(Id); });
            }
        }

        public void DestroyAd()
        {
            Debug.Log("AdColony.InterstitialAd.DestroyAd called.");
            Ads.DestroyAd(Id);
        }

        private bool IsValid()
        {
            return !System.String.IsNullOrEmpty(Id);
        }

        #endregion

    }
}
