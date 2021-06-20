using Playground.Services;
using UnityEditor;

namespace Playground.ToolsMenu
{
    public static class UserDataToolsMenu
    {
        [MenuItem("Tools/Playground/Clear User Data")]
        private static void ClearUserData()
        {
            UserDataUtils.ClearUserData();
        }
    }
}
