using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO;

namespace Netduino.SDCardIO
{
    public class Program
    {
        public static void Main()
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(@"\SD\");
            RecurseFolders(rootDirectory);
        }

        private static void RecurseFolders(DirectoryInfo directory)
        {
            if (directory.Exists)
            {
                Debug.Print(directory.FullName);

                //foreach (FileInfo file in directory.GetFiles())
                //{
                //    Debug.Print(file.FullName);
                //   // File.Delete(file.FullName);
                //}


                //foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                //{
                //   RecurseFolders(subDirectory);
                //}
            }
        }
    }
}
