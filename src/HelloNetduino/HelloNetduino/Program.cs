using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Netduino.Lib.Common;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace HelloNetduino
{
    public class Program
    {
        public static void Main()
        {
            OnBoardLED onboardLED = new OnBoardLED();
            var led = new LED(Pins.GPIO_PIN_D7);

            while (true)
            {
                SOSBlink(onboardLED);

                led.LedState = LedState.On;
                Thread.Sleep(1000);

                led.LedState = LedState.Off;
                Thread.Sleep(500);
            }
        }

        private static void SOSBlink(LED led)
        {
            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);

            led.LedState = LedState.On;
            Thread.Sleep(250);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(250);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(250);
            led.LedState = LedState.Off;
            Thread.Sleep(250);

            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
            led.LedState = LedState.On;
            Thread.Sleep(450);
            led.LedState = LedState.Off;
            Thread.Sleep(250);
        }
    }
}
