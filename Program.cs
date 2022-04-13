using System;

namespace CMP1124M_Assignment
{
    public class Program
    {
        private const int NumberOfShares = 3;
        public static void Main(string[] args)
        {
            Process256();
        }

        static void Process256()
        {
            // Create and initialize jagged array storing the shares
            int[][] shareValues256 = new int[NumberOfShares][];
            for (int i = 0; i < shareValues256.Length; i++)
            {
                // initializing the jagged array
                shareValues256[i] = new int[256];
            }

            // read share files into array
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

            // select which arrays to sort, search and display
            Console.WriteLine("What arrays do you want to sort & search");
            Console.WriteLine("1 - Share_1_256.txt\n2 - Share_2_256.txt\n3 - Share_3_256.txt");
            MessagePrompt arraySelectionPrompt = new MessagePrompt("Select which array(s) you want to process");
            arraySelectionPrompt.AddOption("Share_1_256.txt");
            arraySelectionPrompt.AddOption("Share_2_256.txt");
            arraySelectionPrompt.AddOption("Share_3_256.txt");
            // now have the responses (the indexes of which arrays to use)
            int[] responses = arraySelectionPrompt.ShowPromptMultiSelect();
            int[][] responseArrays = new int[responses.Length][];
            int index = 0;
            foreach (int i in responses)
            {
                Console.WriteLine($"\n---\n256 array index: {i}");

                ProcessArray(shareValues256[i]);

                index++;
            }
        }

        static void ProcessArray(int[] array)
        {
            // Sort/reverse arrays
            // TODO: Prompt to select which sorting algorithm to use
            int[] ascendingOrder = Sorter.BubbleSort(array);
            int[] descendingOrder = Sorter.ReverseOrder(ascendingOrder);

            // display arrays
            Console.WriteLine("Displaying every 10th item in the row");
            Console.WriteLine("Index\tAsc.\tDesc.");
            for (int i = 0; i < ascendingOrder.Length; i += 10)
            {
                Console.WriteLine($"{i}\t{ascendingOrder[i]}\t{descendingOrder[i]}");
            }

            // Search arrays
            // TODO: Search the selected array for a user-defined value, if the value exists, then provide its location (if it appears more than once then provide **ALL** the locations) otherwise provide error message
            MessagePrompt sortTypeSelection = new MessagePrompt("What type of sort would you like to use?");
            sortTypeSelection.AddOption("Binary Search");
            foreach (int sel in sortTypeSelection.ShowPromptMultiSelect())
            {
                int search = MessagePrompt.QuickShowMessageInt("What number do you want to search for?");
                int[] result = new int[0];
                switch (sel)
                {
                    case 0:
                        try
                        {
                            result = Searcher.BinarySearch(ascendingOrder, search);
                        }
                        catch (Searcher.SearchNotFoundException except)
                        {
                            Console.WriteLine($"Couldn't find search: {except.Message}");
                        }
                        break;
                }
                foreach (int r in result)
                {
                    Console.WriteLine($"Found {ascendingOrder[r]} at index {r}");
                }
            }
        }
    }
}
