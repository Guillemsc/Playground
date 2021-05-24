using System.Runtime.CompilerServices;
using SRDebugger.Services;
using SRF.Service;

[assembly: InternalsVisibleTo("StompyRobot.SRDebugger.Editor")]

public static class SRDebug
{
    public const string Version = SRDebugger.VersionInfo.Version;

    public static IDebugService Instance
    {
        get { return SRServiceManager.GetService<IDebugService>(); }
    }

    public static void Init()
    {
        // Initialize console if it hasn't already initialized.
        SRServiceManager.GetService<IConsoleService>();

        // Load the debug service
        SRServiceManager.GetService<IDebugService>();
    }
}
