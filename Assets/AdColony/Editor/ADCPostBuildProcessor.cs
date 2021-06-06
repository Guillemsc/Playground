#if UNITY_IOS || UNITY_ANDROID

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace AdColony.Editor
{
    public class ADCPostBuildProcessor : MonoBehaviour
    {

#if UNITY_CLOUD_BUILD
        public static void OnPostprocessBuildiOS(string exportPath) {
            OnPostprocessBuild(BuildTarget.iOS, exportPath);
        }
#endif

        [PostProcessBuildAttribute(1)]
        public static void OnPostprocessBuild(BuildTarget buildTarget, string buildPath)
        {
            if (buildTarget == BuildTarget.iOS)
            {
#if UNITY_IOS
                Debug.Log("AdColony: OnPostprocessBuild");
                UpdateProject(buildTarget, buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj");
                UpdateProjectPlist(buildTarget, buildPath + "/Info.plist");
#endif
            }
        }

        private static void UpdateProject(BuildTarget buildTarget, string projectPath)
        {
#if UNITY_IOS
            PBXProject project = new PBXProject();
            project.ReadFromString(File.ReadAllText(projectPath));

#if UNITY_2019_4_OR_NEWER
            string targetId = project.GetUnityFrameworkTargetGuid();
#else
            string targetId = project.TargetGuidByName(PBXProject.GetUnityTargetName());
#endif

            // Required Frameworks
            project.AddFrameworkToProject(targetId, "AdSupport.framework", false);
            project.AddFrameworkToProject(targetId, "AudioToolbox.framework", false);
            project.AddFrameworkToProject(targetId, "AVFoundation.framework", false);
            project.AddFrameworkToProject(targetId, "CoreMedia.framework", false);
            project.AddFrameworkToProject(targetId, "CoreTelephony.framework", false);
            project.AddFrameworkToProject(targetId, "JavaScriptCore.framework", false);
            project.AddFrameworkToProject(targetId, "MessageUI.framework", false);
            project.AddFrameworkToProject(targetId, "MobileCoreServices.framework", false);
            project.AddFrameworkToProject(targetId, "SystemConfiguration.framework", false);

            project.AddFileToBuild(targetId, project.AddFile("usr/lib/libz.1.2.5.dylib", "Frameworks/libz.1.2.5.dylib", PBXSourceTree.Sdk));

            // Optional Frameworks
            project.AddFrameworkToProject(targetId, "Social.framework", true);
            project.AddFrameworkToProject(targetId, "StoreKit.framework", true);
            project.AddFrameworkToProject(targetId, "WatchConnectivity.framework", true);
            project.AddFrameworkToProject(targetId, "Webkit.framework", true);

            // For 3.0 MP classes
            project.AddBuildProperty(targetId, "OTHER_LDFLAGS", "-ObjC -fobjc-arc");

            File.WriteAllText(projectPath, project.WriteToString());
#endif
        }

        private static void UpdateProjectPlist(BuildTarget buildTarget, string plistPath)
        {
#if UNITY_IOS
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
            PlistElementDict root = plist.root;
            var applicationQueriesSchemes = plist.root["LSApplicationQueriesSchemes"] != null ? plist.root["LSApplicationQueriesSchemes"].AsArray() : null;
            if (applicationQueriesSchemes == null)
                applicationQueriesSchemes = plist.root.CreateArray("LSApplicationQueriesSchemes");
            foreach (var scheme in new[]{ "fb", "instagram", "tumblr", "twitter" })
                if (applicationQueriesSchemes.values.Find(x => x.AsString() == scheme) == null)
                    applicationQueriesSchemes.AddString(scheme);
            foreach (var kvp in new[] {
            new []
                { "NSCalendarsUsageDescription", "Some ad content may create a calendar event." }
                ,
            new []
                { "NSPhotoLibraryUsageDescription", "Some ad content may require access to the photo library." }
                ,
            new []
                { "NSCameraUsageDescription", "Some ad content may access camera to take picture." }
                ,
            new []
                { "NSMotionUsageDescription", "Some ad content may require access to accelerometer for interactive ad experience." }
            })
            if (!root.values.ContainsKey(kvp[0]))
                    root.SetString(kvp[0], kvp[1]);
            File.WriteAllText(plistPath, plist.WriteToString());
#endif
        }
    }
}

#endif
