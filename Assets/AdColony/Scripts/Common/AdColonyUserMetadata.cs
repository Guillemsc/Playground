using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AdColony
{
    [Obsolete("UserMetadata is deprecated")]
    public class UserMetadata
    {
        private int _age;
        /// <summary>
        /// Configures the user's age.
        /// Set this property to configure the user's age.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value <= 0)
                {
                    Debug.Log("Tried to set user metadata age with an invalid value. Value will not be included.");
                    return;
                }

                _age = value;
                _data[Constants.UserMetadataAgeKey] = _age;
            }
        }

        private List<string> _interests;
        /// <summary>
        /// Configures the user's interests.
        /// Set this property with an array of NSStrings to configure the user's interests.
        /// </summary>
        public List<string> Interests
        {
            get
            {
                return _interests;
            }
            set
            {
                _interests = value;
                _data[Constants.UserMetadataInterestsKey] = new ArrayList(_interests);
            }
        }

        private string _gender;
        /// <summary>
        /// Configures the user's gender.
        /// Set this property to configure the user's gender.
        /// Note that you should use one of the pre-defined constants below to configure this property.
        /// </summary>
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value == null)
                {
                    Debug.Log("Tried to set user metadata gender with an invalid string. Value will not be included.");
                    return;
                }

                string setGender = value;
                _gender = setGender;
                _data[Constants.UserMetadataGenderKey] = _gender;
            }
        }

        private double _latitude;
        /// <summary>
        /// Configures the user's latitude.
        /// Set this property to configure the user's latitude.
        /// </summary>
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                _data[Constants.UserMetadataLatitudeKey] = _latitude;
            }
        }

        private double _longitude;
        /// <summary>
        /// Configures the user's longitude.
        /// Set this property to configure the user's longitude.
        /// </summary>
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                _data[Constants.UserMetadataLongitudeKey] = _longitude;
            }
        }

        private string _zipCode;
        /// <summary>
        /// Configures the user's zip code.
        /// Set this property to configure the user's zip code.
        /// </summary>
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (value == null)
                {
                    Debug.Log("Tried to set user metadata zip code with an invalid string. Value will not be included.");
                    return;
                }

                string setZipCode = value as string;
                _zipCode = setZipCode;
                _data[Constants.UserMetadataZipCodeKey] = _zipCode;
            }
        }

        private int _householdIncome;
        /// <summary>
        /// Configures the user's household income.
        /// Set this property to configure the user's household income.
        /// </summary>
        public int HouseholdIncome
        {
            get
            {
                return _householdIncome;
            }
            set
            {
                _householdIncome = value;
                _data[Constants.UserMetadataHouseholdIncomeKey] = _householdIncome;
            }
        }

        private string _maritalStatus;
        /// <summary>
        /// Configures the user's marital status.
        /// Set this property to configure the user's marital status.
        /// NOTE: that you should use one of the pre-defined constants below to configure this property.
        /// </summary>
        /// <see cref="AdMetadataMaritalStatusType" />
        public string MaritalStatus
        {
            get
            {
                return _maritalStatus;
            }
            set
            {
                if (value == null)
                {
                    Debug.Log("Tried to set user metadata marital status with an invalid string. Value will not be included.");
                    return;
                }

                string setMaritalStatus = value as string;
                _maritalStatus = setMaritalStatus;
                _data[Constants.UserMetadataMaritalStatusKey] = _maritalStatus;
            }
        }

        private string _educationLevel;
        /// <summary>
        /// Configures the user's education level.
        /// Set this property to configure the user's education level.
        /// NOTE: that you should use one of the pre-defined constants below to configure this property.
        /// </summary>
        /// <see cref="AdMetadataEducationLevelType" />
        public string EducationLevel
        {
            get
            {
                return _educationLevel;
            }
            set
            {
                if (value == null)
                {
                    Debug.Log("Tried to set user metadata education level with an invalid string. Value will not be included.");
                    return;
                }

                string setEducationLevel = value as string;
                _educationLevel = setEducationLevel;
                _data[Constants.UserMetadataEducationLevelKey] = _educationLevel;
            }
        }

        /// <summary>
        /// Sets a supported option.
        /// Use this method to set a string-based option with an arbitrary, string-based value.
        /// </summary>
        /// <param name="value">Value of the option.</param>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// </summary>
        [Obsolete("SetMetadata is deprecated")]
        public void SetMetadata(string key, string value)
        {
            if (key == null)
            {
                return;
            }
            _data[key] = value;
        }

        /// <summary>
        /// Sets a supported option.
        /// Use this method to set a string-based option with an arbitrary, integer-based value.
        /// </summary>
        /// <param name="value">Value of the option.</param>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// </summary>
        [Obsolete("SetMetadata is deprecated")]
        public void SetMetadata(string key, int value)
        {
            if (key == null)
            {
                return;
            }
            _data[key] = value;
        }

        /// <summary>
        /// Sets a supported option.
        /// Use this method to set a string-based option with an arbitrary, double-precision-based value.
        /// </summary>
        /// <param name="value">Value of the option.</param>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// </summary>
        [Obsolete("SetMetadata is deprecated")]
        public void SetMetadata(string key, double value)
        {
            if (key == null)
            {
                return;
            }
            _data[key] = value;
        }

        /// <summary>
        /// Sets a supported option.
        /// Use this method to set a string-based option with an arbitrary, boolean-based value.
        /// </summary>
        /// <param name="value">Value of the option.</param>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// </summary>
        [Obsolete("SetMetadata is deprecated")]
        public void SetMetadata(string key, bool value)
        {
            if (key == null)
            {
                return;
            }
            _data[key] = value;
        }

        /// <summary>
        /// Returns the string-based value associated with the given key.
        /// Call this method to obtain the string-based value associated with the given string-based key.
        /// </summary>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// <returns>The string-based value associated with the given key. Returns `null` if the option has not been set.</returns>
        [Obsolete("GetStringMetadata is deprecated")]
        public string GetStringMetadata(string key)
        {
            return _data.ContainsKey(key) ? _data[key] as string : null;
        }

        /// <summary>
        /// Returns the integer-based value associated with the given key.
        /// Call this method to obtain the integer-based value associated with the given string-based key.
        /// </summary>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// <returns>The integer-based value associated with the given key. Returns `null` if the option has not been set.</returns>
        [Obsolete("GetIntMetadata is deprecated")]
        public int GetIntMetadata(string key)
        {
            return _data.ContainsKey(key) ? Convert.ToInt32(_data[key]) : 0;
        }

        /// <summary>
        /// Returns the double-precision-based value associated with the given key.
        /// Call this method to obtain the double-precision-based value associated with the given string-based key.
        /// </summary>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// <returns>The double-precision-based value associated with the given key. Returns `null` if the option has not been set.</returns>
        [Obsolete("GetDoubleMetadata is deprecated")]
        public double GetDoubleMetadata(string key)
        {
            return _data.ContainsKey(key) ? Convert.ToDouble(_data[key]) : 0.0;
        }

        /// <summary>
        /// Returns the boolean-based value associated with the given key.
        /// Call this method to obtain the boolean-based value associated with the given string-based key.
        /// </summary>
        /// <param name="key"> A string used to configure the option. Strings must be 128 characters or less.</param>
        /// <returns>The boolean-based value associated with the given key. Returns `null` if the option has not been set.</returns>
        [Obsolete("GetBoolMetadata is deprecated")]
        public bool GetBoolMetadata(string key)
        {
            return _data.ContainsKey(key) ? Convert.ToBoolean(Convert.ToInt32(_data[key])) : false;
        }

        #region Internal Methods - do not call these

        public Hashtable ToHashtable()
        {
            return new Hashtable(_data);
        }

        public string ToJsonString()
        {
            return AdColonyJson.Encode(_data);
        }

        public UserMetadata()
        {

        }

        public UserMetadata(Hashtable values)
        {
            _data = new Hashtable(values);

            if (values != null)
            {
                if (values.ContainsKey(Constants.UserMetadataAgeKey))
                {
                    _age = Convert.ToInt32(values[Constants.UserMetadataAgeKey]);
                }
                if (values.ContainsKey(Constants.UserMetadataInterestsKey))
                {
                    ArrayList interests = values[Constants.UserMetadataInterestsKey] as ArrayList;
                    Interests = new List<string>();
                    foreach (string interest in interests)
                    {
                        Interests.Add(interest);
                    }
                }
                if (values.ContainsKey(Constants.UserMetadataGenderKey))
                {
                    _gender = values[Constants.UserMetadataGenderKey] as string;
                }
                if (values.ContainsKey(Constants.UserMetadataLatitudeKey))
                {
                    _latitude = Convert.ToDouble(values[Constants.UserMetadataLatitudeKey]);
                }
                if (values.ContainsKey(Constants.UserMetadataLongitudeKey))
                {
                    _longitude = Convert.ToDouble(values[Constants.UserMetadataLongitudeKey]);
                }
                if (values.ContainsKey(Constants.UserMetadataZipCodeKey))
                {
                    _zipCode = values[Constants.UserMetadataZipCodeKey] as string;
                }
                if (values.ContainsKey(Constants.UserMetadataHouseholdIncomeKey))
                {
                    _householdIncome = Convert.ToInt32(values[Constants.UserMetadataHouseholdIncomeKey]);
                }
                if (values.ContainsKey(Constants.UserMetadataMaritalStatusKey))
                {
                    _maritalStatus = values[Constants.UserMetadataMaritalStatusKey] as string;
                }
                if (values.ContainsKey(Constants.UserMetadataEducationLevelKey))
                {
                    _educationLevel = values[Constants.UserMetadataEducationLevelKey] as string;
                }
            }
        }

        private Hashtable _data = new Hashtable();

        #endregion
    }
}
