using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLight
{
    public class TrafficLightsM
    {
        private Signal currentSignal;

        public TrafficLightsM(string inputSignal)
        {
            this.currentSignal = (Signal)Enum.Parse(typeof(Signal), inputSignal);
        }

        public void Update()
        {
            int current = (int)this.currentSignal;
            currentSignal = (Signal) (++current % Enum.GetNames(typeof(Signal)).Length);

        }
    }
}
