// Emily Porter
// 11741612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form1
{
    /// <summary>
    /// Class containing the Random list and the methods for finding the amount of distint integers in the list.
    /// </summary>
    public class RandomList
    {
        /// <summary>
        /// Attribute
        /// Holds the random list of integers between [0, 20000].
        /// </summary>
        private List<int> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomList"/> class.
        /// Constructor for RandomList
        /// Inputs 10000 random integers to list.
        /// </summary>
        public RandomList()
        {
            // initilize list
            this.list = new List<int>();
            var rand = new Random();
            for (int index = 0; index <= 10000; index++)
            {
                this.list.Add(rand.Next(20000));
            }
        }

        /// <summary>
        /// Gets the attribute list in RandomList.
        /// </summary>
        /// <returns>
        /// Returns this.list.
        /// </returns>
        public List<int> GetList()
        {
            return this.list;
        }

        /// <summary>
        /// Sets list to arguement newList.
        /// </summary>
        /// <param name="newList">
        /// What to change the list to.
        /// </param>
        public void SetList(List<int> newList)
        {
            this.list = newList;
        }

        /// <summary>
        /// Checks for distinct integers using hash implementation.
        /// </summary>
        /// <parameters>
        /// Need random list.
        /// </parameters>
        /// <returns>
        /// Number of distinct integers.
        /// </returns>
        public int HashSetDistinct()
        {
            // HashSet<int> result = [.. this.list]; // I have never seen this syntax before, but StyleCop(?) offered this implementation.
            HashSet<int> result = new HashSet<int>(); // create new hash set.
            foreach (int item in this.list) // go through list, adding values to hash set.
            {
                result.Add(item); // cannot add duplicates to hash set, so it will automatically only get distinct integers.
            }

            return result.Count; // return size of hash set.
        }

        /// <summary>
        /// Terribly innefficient size wise, but O(1) space. Iterates through the list for every single possible integer, counting the ones that appear.
        /// </summary>
        /// <returns>
        /// Returns number of distinct integers.
        /// </returns>
        public int O1StorageDistinct()
        {
            int index = 0; // for iterating through list
            int count = 0; // for counting the distinct integers

            // keep running through the list until all possible distinct values have been found
            // either all of them are distinct or the possible integer it could be has run out.
            while (count < 10001 && index < 20001)
            {
                foreach (int item in this.list) // iterate through list.
                {
                    if (index == item) // once distinct integer has been found, increase count and break the loop. 
                    {
                        count++;
                        break;
                    }
                }

                index++; // once we iterated through loop or found distinct number, increase index.
            }

            return count;
        }
    }
}
