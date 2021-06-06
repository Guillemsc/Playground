using UnityEditor;

namespace AdColony.Editor
{
    public class ADCMenu
    {
        [MenuItem("Tools/AdColony/About")]
        public static void About()
        {
            EditorUtility.DisplayDialog(
                ADCPluginInfo.Name,
                "Unity plugin version " + ADCPluginInfo.Version + "\n" +
                "iOS SDK version " + ADCPluginInfo.iOSSDKVersion + "\n" +
                "Android SDK version " + ADCPluginInfo.AndroidSDKVersion,
                "OK");
        }
    }
}
