using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Netduino.Lib.Common
{
    public class LED : OutputPort
    {
        private LedState _ledState;

        public LedState LedState
        {
            get
            {
                return _ledState;
            }
            set
            {
                if (value == LedState.On)
                {
                    this.Write(true);
                }
                else
                {
                    this.Write(false);
                }
                _ledState = value;
            }
        }

        public LED(Cpu.Pin portId)
            :base(portId, false)
        {
            
        }

        protected LED(Cpu.Pin portId, bool initialState, bool glitchFilter, ResistorMode resistorMode)
            :base(portId, initialState, glitchFilter, resistorMode)
        {
            
        }
    }
}
