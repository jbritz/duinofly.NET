using System.Threading;
using Microsoft.SPOT;
using Netduino.Lib.Common;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.PhotoCell
{
    public class Program
    {
        public static void Main()
        {
            //Remember to use the 10K resistor and take the reading in parallel
            //using the 3.3V output makes you less likely to hit the 255 cap
            var photocell = new Photoresistor(Pins.GPIO_PIN_A0);

            var dimableLED1 = new VariableLED(Pins.GPIO_PIN_D10);
            var dimableLED2 = new VariableLED(Pins.GPIO_PIN_D5);

            while (true)
            {
                double light = photocell.Read();
                Debug.Print(light.ToString());

                if (light < 300)
                {
                    if (light < 200)
                    {
                        dimableLED1.Brighten();
                        dimableLED2.Dim();
                    }
                    if (light < 100)
                    {
                        dimableLED1.Brighten();
                        dimableLED2.Brighten();
                    }
                }
                else
                {
                    if (light > 200)
                    {
                        dimableLED1.Dim();
                    }
                    if (light > 400)
                    {
                        dimableLED2.Dim();
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
