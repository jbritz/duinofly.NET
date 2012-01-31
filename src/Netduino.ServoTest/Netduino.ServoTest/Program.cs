using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Netduino.Lib.Common;

namespace Netduino.ServoTest
{
    public class Program
    {
        public static void Main()
        {
            // write your code here

            var servo = new Servo(Pins.GPIO_PIN_D10);

           while(true)
           {
                for (int i = 0; i <= 180; i += 4)
                {
                    servo.Degree = i;
                    Thread.Sleep(10);
                }

                for (int i = 180; i >= 0; i -= 4)
                {
                    servo.Degree = i;
                    Thread.Sleep(10);
                }
            }
        }
    }
}
