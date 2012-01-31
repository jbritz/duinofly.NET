using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.Lib.Common
{
    public class OnBoardLED : LED
    {
        public OnBoardLED()
            :base(Pins.ONBOARD_LED)
        {
            
        }
    }
}
