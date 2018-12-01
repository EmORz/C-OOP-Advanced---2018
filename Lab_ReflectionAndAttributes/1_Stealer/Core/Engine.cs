using System;

namespace _1_Stealer.Core
{
    public class Engine
    {
        public void Run()
        {
            Spy spy = new Spy();
            var result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
