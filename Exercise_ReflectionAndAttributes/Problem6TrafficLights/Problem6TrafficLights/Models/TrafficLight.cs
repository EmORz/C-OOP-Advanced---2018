using Problem6TrafficLights.Enum;

namespace Problem6TrafficLights.Models
{
    public class TrafficLight
    {
        private Signal currentSignal;

        public TrafficLight(string signal)
        {
            this.currentSignal = (Signal)System.Enum.Parse(typeof(Signal), signal);
        }

        public void Update()
        {
            int previos = (int)currentSignal;
            currentSignal = (Signal)(++previos % System.Enum.GetNames(typeof(Signal)).Length);

        }
    }
}
