using System;

namespace CMP1124M_Assignment
{
    public static class Sorter
    {
        public static int[] BubbleSort(int[] input)
        {
            _counter = 0;
            int[] currentOrder = input;
            for (int j = 0; j < input.Length - 1; j++)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (!(currentOrder[i] < currentOrder[i + 1]))
                    {
                        // need to swap the two values
                        int t = currentOrder[i + 1];
                        currentOrder[i + 1] = currentOrder[i];
                        currentOrder[i] = t;
                    }
                    _counter++;
                }
            }
            Console.WriteLine("Number of iterations = " + _counter);
            return currentOrder;
        }

        private static int _counter = 0;

        public static int[] BeginMergeSort(int[] input)
        {
            _counter = 0;
            int[] result = MergeSort(input.ToList()).ToArray();
            Console.WriteLine("Number of iterations = " + _counter);
            return result;
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            _counter++;
            if (unsorted.Count <= 1)
            {
                // can not split the list any further so return.
                return unsorted;
            }

            // set up the new lists for the sub-arrays
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // calculate the midpoint to split the list into
            int middle = unsorted.Count / 2;

            // split the list into left/right sub-lists
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            // begin/continue the recursive function until reach the end
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            _counter++;
            List<int> result = new List<int>();

            // while there are still elements left to be processed in left OR right arrays
            while (left.Count > 0 || right.Count > 0)
            {
                // if there are still comparisons to be made in left AND right arrays
                if (left.Count > 0 && right.Count > 0)
                {
                    // compare the first values of the lists
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right.First());
                        right.RemoveAt(0);
                    }
                }
                // Some situations lead to having one of the sides having one more/less element than the other
                // so check and deal with the remaining element
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }
            return result;
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