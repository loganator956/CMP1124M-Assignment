using System;

namespace CMP1124M_Assignment
{
    public class Program
    {
        private const int NumberOfShares = 3;
        public static void Main(string[] args)
        {
            int[][] shareValues256 = new int[NumberOfShares][];
            for (int i = 0; i < shareValues256.Length; i++)
            {
                // initializing the jagged array
                shareValues256[i] = new int[256];
            }
            for (int i = 0; i < NumberOfShares; i++)
            {
                string fileName = $"Share_{i + 1}_256.txt";
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"\nERROR: CANNOT FIND FILE: {fileName}\nExiting");
                    return;
                }
                string[] lines = File.ReadAllLines(fileName);
                for (int line = 0; line < lines.Length; line++)
                {
                    shareValues256[i][line] = int.Parse(lines[line]);
                }
            }

            // TODO: Select Arrays
            // TODO: Allow for selecting multiple arrays
            MessagePrompt message = new MessagePrompt($"Select which array to use (1-3)");
            int selectedArrayIndex = message.ShowMessageNumericalResponse(1,3) - 1;

            // TODO: Sort into ascending and descending order 
            

            // TODO: Display every 10th value of the SELECTED arrays
        }
    }
}
