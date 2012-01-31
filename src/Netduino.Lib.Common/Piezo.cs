using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Netduino.Lib.Common
{
    public class PiezoKnockSensor : AnalogInput
    {
        public PiezoKnockSensor(Cpu.Pin pin) 
            : base(pin)
        {
        }
    }
}
