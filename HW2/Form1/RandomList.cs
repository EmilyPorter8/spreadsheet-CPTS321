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
            // HashSet<int> result = [.. this.list]; // I have never seen this syntax before, but StyleCop offered this implementation.
            HashSet<int> result = new HashSet<int>();
            foreach (int item in this.list)
            {
                result.Add(item);
            }

            return result.Count;
        }

        /// <summary>
        /// currently skeleton code.
        /// </summary>
        /// <returns>
        /// Will return number of distinct integers.
        /// </returns>
        public int O1StorageDistinct()
        {

            return 0;
        }
    }
}
