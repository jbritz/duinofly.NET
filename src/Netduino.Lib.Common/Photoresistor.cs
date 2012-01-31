using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Netduino.Lib.Common
{
    public class Photoresistor : AnalogInput
    {
        public Photoresistor(Cpu.Pin pin) 
            : base(pin)
        {
           // this.SetRange(0,255);
        }
    }
}
