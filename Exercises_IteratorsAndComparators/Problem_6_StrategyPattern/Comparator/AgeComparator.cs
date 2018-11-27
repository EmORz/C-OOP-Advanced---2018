namespace Problem_6_StrategyPattern.Comparator
{
    using Models;
    using System.Collections.Generic;

    public class AgeComparator: IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Age.CompareTo(y.Age);
            return result;
        }
    }
}
