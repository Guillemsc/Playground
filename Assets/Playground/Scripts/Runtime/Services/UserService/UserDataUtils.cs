using Juce.CoreUnity.Files;
using System.IO;

namespace Playground.Services
{
    public static class UserDataUtils
    {
        public static string GetUserDataPath()
        {
            return PathUtils.CombinePaths(PathUtils.PersistentDataPath, UserData.LocalPath); 
        }

        public static void ClearUserData()
        {
            string path = GetUserDataPath();

            File.Delete(path);
        }
    }
}
