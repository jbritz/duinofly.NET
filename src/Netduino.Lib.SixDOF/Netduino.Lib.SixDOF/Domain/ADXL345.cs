using System;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Netduino.Lib.SixDOF.Domain
{
    public class ADXL345
    {
        public const int TO_READ = 6; // number of bytes to read (2 bytes for each axis)

        /* -- ADXL345 addresses --*/
        public const byte ADXL345_ADDR_ALT_HIGH = 0x1D; // ADXL345 address when ALT is connected to HIGH
        public const byte ADXL345_ADDR_ALT_LOW = 0x53; // ADXL345 address when ALT is connected to LOW

        /* ------- Register names ------- */
        public const byte ADXL345_DEVID = 0x00;
        public const byte ADXL345_RESERVED1 = 0x01;
        public const byte ADXL345_THRESH_TAP = 0x1d;
        public const byte ADXL345_OFSX = 0x1e;
        public const byte ADXL345_OFSY = 0x1f;
        public const byte ADXL345_OFSZ = 0x20;
        public const byte ADXL345_DUR = 0x21;
        public const byte ADXL345_LATENT = 0x22;
        public const byte ADXL345_WINDOW = 0x23;
        public const byte ADXL345_THRESH_ACT = 0x24;
        public const byte ADXL345_THRESH_INACT = 0x25;
        public const byte ADXL345_TIME_INACT = 0x26;
        public const byte ADXL345_ACT_INACT_CTL = 0x27;
        public const byte ADXL345_THRESH_FF = 0x28;
        public const byte ADXL345_TIME_FF = 0x29;
        public const byte ADXL345_TAP_AXES = 0x2a;
        public const byte ADXL345_ACT_TAP_STATUS = 0x2b;
        public const byte ADXL345_BW_RATE = 0x2c;
        public const byte ADXL345_POWER_CTL = 0x2d;
        public const byte ADXL345_INT_ENABLE = 0x2e;
        public const byte ADXL345_INT_MAP = 0x2f;
        public const byte ADXL345_INT_SOURCE = 0x30;
        public const byte ADXL345_DATA_FORMAT = 0x31;
        public const byte ADXL345_DATAX0 = 0x32;
        public const byte ADXL345_DATAX1 = 0x33;
        public const byte ADXL345_DATAY0 = 0x34;
        public const byte ADXL345_DATAY1 = 0x35;
        public const byte ADXL345_DATAZ0 = 0x36;
        public const byte ADXL345_DATAZ1 = 0x37;
        public const byte ADXL345_FIFO_CTL = 0x38;
        public const byte ADXL345_FIFO_STATUS = 0x39;

        public const byte ADXL345_BW_1600 = 0xF; // 1111
        public const byte ADXL345_BW_800 = 0xE; // 1110
        public const byte ADXL345_BW_400 = 0xD; // 1101  
        public const byte ADXL345_BW_200 = 0xC; // 1100
        public const byte ADXL345_BW_100 = 0xB; // 1011  
        public const byte ADXL345_BW_50 = 0xA; // 1010 
        public const byte ADXL345_BW_25 = 0x9; // 1001 
        public const byte ADXL345_BW_12 = 0x8; // 1000 
        public const byte ADXL345_BW_6 = 0x7; // 0111
        public const byte ADXL345_BW_3 = 0x6; // 0110


        /* 
        Interrupt PINs
        INT1: 0
        INT2: 1
        */
        public const byte ADXL345_INT1_PIN = 0x00;
        public const byte ADXL345_INT2_PIN = 0x01;

        /* 
        Interrupt bit position
        */
        public const byte ADXL345_INT_DATA_READY_BIT = 0x07;
        public const byte ADXL345_INT_SINGLE_TAP_BIT = 0x06;
        public const byte ADXL345_INT_DOUBLE_TAP_BIT = 0x05;
        public const byte ADXL345_INT_ACTIVITY_BIT = 0x04;
        public const byte ADXL345_INT_INACTIVITY_BIT = 0x03;
        public const byte ADXL345_INT_FREE_FALL_BIT = 0x02;
        public const byte ADXL345_INT_WATERMARK_BIT = 0x01;
        public const byte ADXL345_INT_OVERRUNY_BIT = 0x00;

        public const byte ADXL345_OK = 1; // no error
        public const byte ADXL345_ERROR = 0; // indicates error is predent

        public const byte ADXL345_NO_ERROR = 0; // initial state
        public const byte ADXL345_READ_ERROR = 1; // problem reading accel
        public const byte ADXL345_BAD_ARG = 2; // bad method argument
        private byte[] _buff = new byte[6]; //6 bytes buffer for saving data read from the device
        private byte _dev_address;

        public float[] _gains = new float[3]; // counts to Gs
        private int _timeInactivity;
        public byte error_code; // Initial state
        public bool status; // set when error occurs 


        public int TapThreshold { get; set; }

        public float AxisGains { get; set; }

        public int TapDuration { get; set; }

        public int DoubleTapLatency { get; set; }

        public int DoubleTapWindow { get; set; }

        public int ActivityThreshold { get; set; }

        public int InactivityThreshold { get; set; }

        public int TimeInactivity
        {
            get { return _timeInactivity; }
        }

        public int FreeFallThreshold { get; set; }

        public int FreeFallDuration { get; set; }

        public void Init(byte address)
        {
            //address = (byte)(address >> 1);
            _dev_address = address;
            _adapter = I2CAdapter.Instance;
            _slaveConfig = new I2CDevice.Configuration(_dev_address, 100);
            PowerOn();
        }

        public void PowerOn()
        {
            WriteTo(ADXL345_POWER_CTL, new byte[] {8});
        }

        public void ReadAccel(out int[] xyz)
        {
            int x;
            int y;
            int z;
            ReadAccel(out x, out y, out z);
            xyz = new int[3];
            xyz[0] = x;
            xyz[1] = y;
            xyz[2] = z;
        }

        public void ReadAccel(out int x, out int y, out int z)
        {
            ReadFrom(ADXL345_DATAX0, TO_READ, _buff); //read the acceleration data from the ADXL345

            // each axis reading comes in 10 bit resolution, ie 2 bytes.  Least Significat Byte first!!
            // thus we are converting both bytes in to one int
            x = (((int)_buff[1]) << 8) | _buff[0];
            y = (((int)_buff[3]) << 8) | _buff[2];
            z = (((int)_buff[5]) << 8) | _buff[4];
        }

        public void GetGxyz(float[] xyz)
        {
            int i;
            //int xyz_int[3];
            int[] xyz_int = new int[3];
            ReadAccel(out xyz_int);
            for(i=0; i<3; i++)
            {
                xyz[i] = xyz_int[i] * _gains[i];
            }
        }

        public void SetAxisOffset(int x, int y, int z)
        {
        }

        public void GetAxisOffset(int x, int y, int z)
        {
        }


        public bool IsActivityXEnabled;

        public bool IsActivityYEnabled;

        public bool IsActivityZEnabled;

        public bool IsInactivityXEnabled;

        public bool IsInactivityYEnabled;

        public bool IsInactivityZEnabled;

        public bool IsActivityAc;

        public bool IsInactivityAc;


        public bool SuppressBit { get; set; }

        public bool TapDetectionOnX { get; set; }

        public bool TapDetectionOnY { get; set; }

        public bool TapDetectionOnZ { get; set; }

        public void SetActivityX(bool state)
        {
        }

        public void SetActivityY(bool state)
        {
        }

        public void SetActivityZ(bool state)
        {
        }

        public void SetInactivityX(bool state)
        {
        }

        public void SetInactivityY(bool state)
        {
        }

        public void SetInactivityZ(bool state)
        {
        }

        public bool IsActivitySourceOnX;

        public bool IsActivitySourceOnY;

        public bool IsActivitySourceOnZ;

        public bool IsTapSourceOnX;

        public bool IsTapSourceOnY;

        public bool IsTapSourceOnZ;

        public bool IsAsleep;

        public bool IsLowPower;
        private byte _status;
        private byte _errorCode;
        private I2CAdapter _adapter;
        private I2CDevice.Configuration _slaveConfig;

        public void SetLowPower(bool state)
        {
        }

        public float GetRate { get; set; }

        public byte BwCode { get; set; }

        public byte GetInterruptSource()
        {
            throw new NotImplementedException(); 
        }

        public bool GetInterruptSource(byte interruptBit)
        {
            throw new NotImplementedException(); 
        }

        public bool GetInterruptMapping(byte interruptBit)
        {
            throw new NotImplementedException(); 
        }

        public void SetInterruptMapping(byte interruptBit, bool interruptPin)
        {
            throw new NotImplementedException(); 
        }

        public bool IsInterruptEnabled(byte interruptBit)
        {
            throw new NotImplementedException(); 
        }

        public void SetInterrupt(byte interruptBit, bool state)
        {
        }

        public void GetRangeSetting(byte rangeSetting)
        {
        }

        public void SetRangeSetting(int val)
        {
        }

        public bool GetSelfTestBit()
        {
            throw new NotImplementedException(); 
        }

        public void SetSelfTestBit(bool selfTestBit)
        {
        }

        public bool GetSpiBit()
        {
            throw new NotImplementedException(); 
        }

        public void SetSpiBit(bool spiBit)
        {
        }

        public bool GetInterruptLevelBit()
        {
            throw new NotImplementedException(); 
        }

        public void SetInterruptLevelBit(bool interruptLevelBit)
        {
        }

        public bool GetFullResBit()
        {
            throw new NotImplementedException(); 
        }

        public void SetFullResBit(bool fullResBit)
        {
        }

        public bool GetJustifyBit()
        {
            throw new NotImplementedException(); 
        }

        public void SetJustifyBit(bool justifyBit)
        {
        }

        public void PrintAllRegister()
        {
        }

        public void WriteTo(byte address, byte[] val)
        {
            //address = (byte)(address >> 1);
            _adapter.WriteInternalAddressBytes(_slaveConfig, val, address, 1);
        }

        private void ReadFrom(byte address, byte num, byte[] buff)
        {
            //address = (byte) (address >> 1);
            _adapter.ReadInternalAddressBytes(_slaveConfig, buff, address, 1);
        }

        private void SetRegisterBit(byte regAdress, int bitPos, bool state)
        {
        }

        private bool GetRegisterBit(byte regAdress, int bitPos)
        {
            throw new NotImplementedException(); 
        }

        private void PrintByte(byte val)
        {
            
        }

        public ADXL345()
        {
            _status = ADXL345_OK;
            _errorCode = ADXL345_NO_ERROR;

            _gains[0] = 0.00376390f;
            _gains[1] = 0.00376009f;
            _gains[2] = 0.00349265f;
        }
    }
}