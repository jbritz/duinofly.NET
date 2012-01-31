using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Netduino.Lib.Common
{
    public class VariableLED : PWM
    {
        private uint _brightness;

        public uint Brightness
        {
            get
            {
                return _brightness;
            }
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                else if(value < 0)
                {
                    value = 0;
                }

                _brightness = value;
            }
        }

        public VariableLED(Cpu.Pin pin)
            : base(pin)
        {
            TurnOff();
        }

        public void Dim()
        {
            if (Brightness > 20)
            {
                Brightness -= 20;
            }
            else
            {
                TurnOff();
            }
            this.SetDutyCycle(Brightness);
        }

        public void Brighten()
        {
            Brightness += 20;
            this.SetDutyCycle(Brightness);
        }

        public void TurnOff()
        {
            Brightness = 0;
            this.SetDutyCycle(Brightness);
        }

        public void FullBrightness()
        {
            Brightness = 100;
            this.SetDutyCycle(Brightness);
        }
    }
}
