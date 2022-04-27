using DTSoundData;

namespace DreamTeamSoundToolConsole;

/// <summary>
/// Main entrypoint of the application
/// </summary>
class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(args[0]);
        // Exit if no arguments are supplied
        if (args.Length == 0)
        {
            return;
        }
        // Get path to ARC-File, then extract to the supplied or current directory
        new SoundDataArc(args[0]).extractArchive(args.Length != 2 ? Directory.GetCurrentDirectory() : args[1]);
    }
}