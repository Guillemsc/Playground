using Juce.CoreUnity.Files;
using System.IO;

namespace Playground.Utils.Persistence
{
    public static class PersistenceDataUtils
    {
        public static string GetPersistanceDataFile(string fileName)
        {
            return $"{GetPersistanceDataFolder()}{PathUtils.DirectorySeparatorChar}{fileName}";
        }

        public static string GetPersistanceDataFolder()
        {
            return PathUtils.CombinePaths(PathUtils.PersistentDataPath, "PersistanceData");
        }

        public static void ClearPersistanceData()
        {
            string path = GetPersistanceDataFolder();

            Directory.Delete(path);
        }
    }
}
