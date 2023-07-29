using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace MLModel1_ConsoleApp1
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO.Ports;
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://deft-jelly-f65237.netlify.app");
            while (true)
            {
                string element = driver.FindElement(By.Id("convert_text")).Text;
                Console.WriteLine("Website Read: " + Convert.ToString(element));
                Ai(element);
                Thread.Sleep(2000);
            }
        }
        static void Ai(string elementRead)
        {
            string CHUNGUSINPUT = elementRead;
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                Col0 = @CHUNGUSINPUT,
            };
            // Make a single prediction on the sample data and print results
            var Result = MLModel1.Predict(sampleData);


            // 0 is bad
            // 1 is good
            Console.WriteLine($"Result: " + Result.Prediction);
            Console.WriteLine("-------------------------------------");
        }
    }
}
