using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TrafficLight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            TrafficLightsM[] trafficLightsMs = new TrafficLightsM[input.Length];

            for (int j = 0; j < input.Length; j++)
            {
                trafficLightsMs[j] =
                    (TrafficLightsM) Activator.CreateInstance(typeof(TrafficLightsM), new object[] {input[j]});
            }

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();

                foreach (TrafficLightsM trafficLightsM in trafficLightsMs)
                {
                    trafficLightsM.Update();
                    var field = typeof(TrafficLightsM).GetField("currentSignal",
                        BindingFlags.Instance | BindingFlags.NonPublic).GetValue(trafficLightsM).ToString();
                    sb.Append(field+" ");
                }
                Console.WriteLine(sb.ToString().Trim());
            }

        }
    }
}
