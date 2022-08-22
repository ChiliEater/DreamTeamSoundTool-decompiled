using System.Diagnostics;
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
            Console.WriteLine("Arguments: \"Path to ARC-File\" \"Path to output folder\"");
            return;
        }

        try
        {
            // Get path to ARC-File, parse archive, then extract to the supplied or current directory
            new SoundDataArc(args[0]).extractArchive(args.Length != 2 ? Directory.GetCurrentDirectory() : args[1]);
        }
        catch (Exception e)
        {
            Debug.Write(e);
        }
    }
}