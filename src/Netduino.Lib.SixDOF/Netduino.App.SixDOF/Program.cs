using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Netduino.Lib.SixDOF.Domain;

namespace Netduino.App.SixDOF
{
    public class Program
    {
        public static void Main()
        {
            ADXL345 adxl = new ADXL345();
            adxl.Init(ADXL345.ADXL345_ADDR_ALT_LOW);

            while (true)
            {
                Thread.Sleep(150);

                var results = new int[3];
                adxl.ReadAccel(out results);

                Debug.Print(results[0].ToString());
            }
        }

    }
}
