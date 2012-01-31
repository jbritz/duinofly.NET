using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Netduino.Lib.Common
{
    public class Servo : PWM
    {
        private int[] _timingRange = new int[2];

        /// <summary>
        /// Set servo inversion
        /// </summary>
        public bool _inverted = false;


        public Servo(Cpu.Pin pin) 
            : base(pin)
        {
            this.SetDutyCycle(0);

            _timingRange[0] = 500;
            _timingRange[1] = 2900;
        }

        public void Spin()
        {
            this.SetDutyCycle(80);
        }

        public void Stop()
        {
            this.SetDutyCycle(0);
        }

        /// <summary>
        /// Set the servo degree
        /// </summary>
        public double Degree
        {
            set
            {
                /// Range checks
                if (value > 180)
                    value = 180;

                if (value < 0)
                    value = 0;

                // Are we inverted?
                if (_inverted)
                    value = 180 - value;

                // Set the pulse
                this.SetPulse(20000, (uint)map((long)value, 0, 180, _timingRange[0], _timingRange[1]));
            }
        }

        /// <summary>
        /// Used internally to map a value of one scale to another
        /// </summary>
        /// <param name="x"></param>
        /// <param name="in_min"></param>
        /// <param name="in_max"></param>
        /// <param name="out_min"></param>
        /// <param name="out_max"></param>
        /// <returns></returns>
        private long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

    }
}
