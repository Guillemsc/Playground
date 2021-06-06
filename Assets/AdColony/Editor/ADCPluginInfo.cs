namespace AdColony.Editor
{
    public static class ADCPluginInfo
    {
        public static string Version = Constants.AdapterVersion;
        public static string AndroidSDKVersion = Constants.AndroidSDKVersion;
        public static string iOSSDKVersion = Constants.iOSSDKVersion;
#if UNITY_2019_4_OR_NEWER
        public const UnityEditor.AndroidSdkVersions RequiredAndroidVersion = UnityEditor.AndroidSdkVersions.AndroidApiLevel19;
#elif UNITY_5_6_OR_NEWER
        public const UnityEditor.AndroidSdkVersions RequiredAndroidVersion = UnityEditor.AndroidSdkVersions.AndroidApiLevel16;
#else
        public const UnityEditor.AndroidSdkVersions RequiredAndroidVersion = UnityEditor.AndroidSdkVersions.AndroidApiLevel14;
#endif
        public const string Name = "AdColony";
    }
}
