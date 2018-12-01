using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Problem6TrafficLights.Models;

namespace Problem6TrafficLights.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine().Split().ToArray();

            TrafficLight[] trafficLights = new TrafficLight[input.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] =
                    (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] {input[i]});
            }

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> result = new List<string>();

                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();
                    var field = typeof(TrafficLight).GetField("currentSignal",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                    var temp = field.GetValue(trafficLight).ToString();
                    result.Add(temp);
                }
                Console.WriteLine(string.Join(" ", result));
            }

        }
    }
}
