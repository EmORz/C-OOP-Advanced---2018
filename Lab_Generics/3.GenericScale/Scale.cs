
namespace GenericScale
{
    using System;
    using System.Collections.Generic;

    public class Scale<T>
    where T: IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            if (this.left.CompareTo(right)>0)
            {
                return this.left;
            }
            else if (this.right.CompareTo(left) > 0)
            {
                return this.right;
            }

            return default(T);
        }
    }
}
