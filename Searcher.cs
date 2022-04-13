using System;
using System.Collections.Generic;

namespace CMP1124M_Assignment
{
    public static class Searcher
    {
        public static int[] BinarySearch(int[] sortedArray, int searchCriteria)
        {
            List<int> foundIndexes = new List<int>();
            int minRange = 0;
            int maxRange = sortedArray.Length - 1;
            int m = (minRange + maxRange) / 2;
            int foundIndex = -1;
            while (true)
            {
                m = (minRange + maxRange) / 2;
                int sel = sortedArray[m];

                if (searchCriteria < sel)
                {
                    // select the left half
                    maxRange = m - 1;
                }
                else if (searchCriteria > sel)
                {
                    // select the right half
                    minRange = m + 1;
                }
                else if (searchCriteria == sel)
                {
                    // must have found our option
                    foundIndex = m;
                    foundIndexes.Add(foundIndex);
                    break;
                }
                if (minRange >= maxRange)
                {
                    // Could not find the item in the array, selected item is the closest
                    throw new SearchNotFoundException($"Cannot find {searchCriteria} in the array. Closest is {sel} at index {m}.");
                }
            }
            if (foundIndex != -1)
            {
                // find how many there are nearby
                int indexOffset = 1;
                while (true)
                {
                    bool found = false;
                    int o1 = m + indexOffset;
                    int o2 = m + -indexOffset;
                    if (o1 < sortedArray.Length)
                    {
                        // check right
                        if (sortedArray[o1] == searchCriteria)
                        {
                            foundIndexes.Add(o1);
                            found = true;
                        }
                    }
                    if (o2 > 0)
                    {
                        // check left
                        if (sortedArray[o2] == searchCriteria)
                        {
                            foundIndexes.Add(o2);
                            found = true;
                        }
                    }
                    if (found == false) { break; } else { indexOffset++; };
                }
            }
            return foundIndexes.ToArray();
        }

        [System.Serializable]
        public class SearchNotFoundException : System.Exception
        {
            public SearchNotFoundException() { }
            public SearchNotFoundException(string message) : base(message) { }
            public SearchNotFoundException(string message, System.Exception inner) : base(message, inner) { }
            protected SearchNotFoundException(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}