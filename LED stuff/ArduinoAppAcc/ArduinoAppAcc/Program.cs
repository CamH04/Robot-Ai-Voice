using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ArduinoAppAcc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerialPort serialPort;
            //com port, baudrate
            serialPort = new SerialPort("COM3", 9600);

            //opens data transmition
            try
            {
                serialPort.Open();
            }
            catch
            {
                Console.WriteLine("Somthings went wrong (COM PORT)");
            }

            // shit that ill be replacing later

            // random letter for which face to display every 3 seconds or so
            string userInput = Console.ReadLine();
            while (userInput != "piss")
            {
                if (userInput == "h")
                {
                    serialPort.Write("h");
                }
                if (userInput == "s")
                {
                    serialPort.Write("s");
                }
                if (userInput == "n")
                {
                    serialPort.Write("n");
                }
                else
                    serialPort.Write("e");
                userInput = Console.ReadLine();
            }
            Console.Write("CODE STOPPED");
            
        }
    }
}
