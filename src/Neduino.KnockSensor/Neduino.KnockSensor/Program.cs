using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Netduino.Lib.Common;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Neduino.KnockSensor
{
    public class Program
    {
        public static void Main()
        {
            // write your code here

            var knockSensor = new PiezoKnockSensor(Pins.GPIO_PIN_A0);

            while (true)
            {
                var soundLevel = knockSensor.Read();
                Debug.Print(soundLevel.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
