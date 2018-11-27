using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4_Froggy.Models
{
    public class Lake<T> : IEnumerable<T>
    {
        private T[] stones;


        public Lake(IEnumerable<T> stones)
        {
            this.stones = stones.ToArray();

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i+=2)
            {
                yield return stones[i];
            }

            var baseIndex = this.stones.Length % 2 == 0 ? stones.Length - 1 : stones.Length - 2;
            for (int i =baseIndex; i >= 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
