namespace ShellyFuckInterpreter;

using System.Text;

public class ShellyFuck
{
    public static string ExecuteShellyFuck(string code)
    {
        int[] memory = new int[1024];
        int pointer = 0;
        StringBuilder output = new StringBuilder();
        int cachedPointer = 0;
        bool shouldUseCachedPointer = false;

        string[] commands = code.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int GetPointerIndex() => shouldUseCachedPointer ? cachedPointer : pointer;

        foreach (string command in commands)
        {
            switch (command)
            {
                case "Шелли":
                    memory[pointer]++;
                    break;
                case "Шелли?":
                    memory[pointer]--;
                    break;
                case "Шелли!":
                    output.Append((char)memory[pointer]);
                    break;
                case "Shelly":
                    pointer++;
                    break;
                case "Shelly!":
                    pointer--;
                    break;
                case "Шелли>":
                    memory[pointer + 1] += memory[GetPointerIndex()];
                    break;
                case "Шелли<":
                    memory[pointer + 1] -= memory[GetPointerIndex()];
                    break;
                case "Шелли,":
                    memory[pointer + 1] *= memory[GetPointerIndex()];
                    break;
                case "Шелли;":
                    if (memory[GetPointerIndex()] != 0)
                        memory[pointer + 1] /= memory[GetPointerIndex()];
                    break;
                case "Шелли:":
                    cachedPointer = pointer;
                    break;
                case "Шелли/":
                    shouldUseCachedPointer = !shouldUseCachedPointer;
                    break;
                default:
                    break;
            }

            if (pointer < 0 || pointer >= memory.Length)
                pointer = 0;
        }

        return output.ToString();
    }
}