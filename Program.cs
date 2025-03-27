namespace ShellyFuckInterpreter;

using System;
using System.IO;
using ShellyFuckInterpreter;

public class ShellyFuckBridge
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: ShellyFuckInterpreter <filename>");
            return;
        }
        
        string filePath = args[0];

        if (!filePath.EndsWith(".shelly"))
        {
            Console.WriteLine("Invalid file path");
            return;
        }
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: {0}", filePath);
            return;
        }
        
        string code = File.ReadAllText(filePath);
        string result = ShellyFuck.ExecuteShellyFuck(code);
        Console.WriteLine(result);
    }
}
