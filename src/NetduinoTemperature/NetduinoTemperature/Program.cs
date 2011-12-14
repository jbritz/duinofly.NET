using System;
using System.Threading;
using MFJuliet;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace NetduinoTemperature
{
    public class Program
    {

        private static Timer _TempPollingTimer;
        private static Timer _PiezoPollingTimer;
        private static AnalogInput tempPin = new AnalogInput(Pins.GPIO_PIN_A0);
        private static AnalogInput piezoPin = new AnalogInput(Pins.GPIO_PIN_A1);
        private static OutputPort greenLed = new OutputPort(Pins.GPIO_PIN_D0, false);
        private static OutputPort yellowLed = new OutputPort(Pins.GPIO_PIN_D1, false);
        private static OutputPort redLed = new OutputPort(Pins.GPIO_PIN_D2, false);
        private static OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);
        private static MFJuliet.NetworkCommander _Commander = new NetworkCommander("192.168.10.74", 8001);

        public static void Main()
        {
            // write your code here
            StartTemperaturePolling();
            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }


        private static void StartTemperaturePolling()
        {
            _TempPollingTimer = new Timer(TempPollingCallBack, null, 1000, 1000);
            _PiezoPollingTimer = new Timer(PiezoPollingCallBack, null, 1000, 1000);
        }

        private static void TempPollingCallBack(object userinfo)
        {
            double avgTemp = GetAverageTemperature();
            Debug.Print(avgTemp.ToString());

            SendValue("TEMP|" + avgTemp.ToString());

            IndicateRead();
        }

        private static double GetCurrentReading()
        {
            return tempPin.Read();
        }

        private static double GetAverageTemperature()
        {
            double totaltemp = 0;
            double avgTemp = 0;

            for (int i = 0; i <= 9; i++)
            {
                totaltemp += GetCurrentReading();
                Thread.Sleep(100);
            }

            avgTemp = totaltemp / 10;
            float volts = (float)((avgTemp / 1024.0) * 3.3);

            double celc = volts * 100;


            //double celc = ((5.0 * avgTemp * 100.0)) / 1024;

            return celc;
        }

        private static void IndicateRead()
        {
            BlickLed(greenLed, 30);
            BlickLed(yellowLed, 30);
            BlickLed(redLed, 30);
        }

        private static void BlickLed(OutputPort port, int interval)
        {
            port.Write(true);
            Thread.Sleep(interval);
            port.Write(false);
        }


        private static void PiezoPollingCallBack(object userinfo)
        {
            var readValue = piezoPin.Read();
            Debug.Print("PIEZO:" + readValue.ToString());

            //SendValue("NOISE|" + readValue.ToString());

            var test = ((int)readValue) + 100;
            SendValue("NOISE|" + test);

            if (readValue > 100)
            {
                BlickLed(onBoardLed, 100);
            }
        }

        private static bool _IsBusy;
        private static void SendValue(string value)
        {

            _IsBusy = true;
            _Commander.SendCommand(value);

            _IsBusy = false;

        }
    }
}
