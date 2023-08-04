using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO.Ports;
using System.Collections.Generic;


namespace MLModel1_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Max"; // Haha because MAX7219 Led Matrix
            // setting up I/O stuff
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

            // setting up Web Scraper stuff
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://deft-jelly-f65237.netlify.app");

            while (true)
            {
                // every 2 seconds it scrapes website, finds element and goes through sentiment anylsis
                string elementRead = driver.FindElement(By.Id("convert_text")).Text;
                Console.WriteLine("Website Read: " + Convert.ToString(elementRead));
                string CHUNGUSINPUT = elementRead;

                MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                {
                    Col0 = @CHUNGUSINPUT,
                };
                // Make a single prediction on the sample data and print results
                var Result = MLModel1.Predict(sampleData);
                float VeiwResult = Result.Prediction;
                // 0 is bad
                // 1 is good
                Console.WriteLine($"Result: " + Result.Prediction);


                // checks n stuff
                if(elementRead == "{}")
                {
                    Console.WriteLine("Writing Nutruela");
                    serialPort.Write("n");
                    Console.WriteLine("-------------------------------------");
                    Thread.Sleep(2000);
                    continue;
                }
                // writing happy or sad
                if (VeiwResult == Convert.ToDouble(1))
                {
                    Console.WriteLine("Writing Happy");
                    serialPort.Write("h");
                    if (elementRead.Contains(name))
                    {
                        serialPort.Write("l");
                        Console.WriteLine("NAME CONTAINED");
                        Thread.Sleep(2000);
                        serialPort.Write("h");
                        Console.WriteLine("Writing Happy");
                    }
                    Console.WriteLine("-------------------------------------");
                }
                if (VeiwResult == Convert.ToDouble(0))
                {
                    Console.WriteLine("Writing Sad");
                    serialPort.Write("s");
                    Console.WriteLine("-------------------------------------");
                }
                Thread.Sleep(3000);
            }
            
        }
    }
}
