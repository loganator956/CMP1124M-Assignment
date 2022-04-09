using System;

namespace CMP1124M_Assignment
{
    public static class Sorter
    {
        public static int[] BubbleSort(int[] input)
        {
            int[] currentOrder = input;
            for (int j = 0; j < input.Length - 1; j++)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (currentOrder[i] < currentOrder[i + 1])
                    {
                        // sorting in ascending order by default so this is already in correct order
                    }
                    else
                    {
                        // need to swap the two values
                        int t = currentOrder[i + 1];
                        currentOrder[i + 1] = currentOrder[i];
                        currentOrder[i] = t;
                    }
                }
            }
            return currentOrder;
        }

        public static int[] ReverseOrder(int[] input)
        {
            int[] reversedOrder = new int[input.Length];
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedOrder[i] = input[(input.Length - 1) - i];
            }
            return reversedOrder;
        }
    }
}