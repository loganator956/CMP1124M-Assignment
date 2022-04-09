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

            Console.WriteLine("What arrays do you want to sort & search");
            Console.WriteLine("1 - Share_1_256.txt\n2 - Share_2_256.txt\n3 - Share_3_256.txt");
            MessagePrompt arraySelectionPrompt = new MessagePrompt("Select which array(s) you want to process");
            arraySelectionPrompt.AddOption("Share_1_256.txt");
            arraySelectionPrompt.AddOption("Share_2_256.txt");
            arraySelectionPrompt.AddOption("Share_3_256.txt");
            // now have the responses (the indexes of which arrays to use)
            int[] responses = arraySelectionPrompt.ShowPromptMultiSelect();

            // TODO: Sort into ascending and descending order 
            foreach (int i in responses)
            {
                Console.WriteLine($"\n---\narray index: {i}");
                // TODO: Prompt to select which sorting algorithm to use
                int[] ascendingOrder = Sorter.BubbleSort(shareValues256[i]);
                int[] descendingOrder = Sorter.ReverseOrder(ascendingOrder);

                Console.WriteLine("Displaying every 10th item in the row");
                Console.WriteLine("Index\tAsc.\tDesc.");

                for (int j = 0; j < ascendingOrder.Length; j += 10)
                {
                    Console.WriteLine($"{j}\t{ascendingOrder[j]}\t{descendingOrder[j]}");
                }
            }
        }
    }
}
