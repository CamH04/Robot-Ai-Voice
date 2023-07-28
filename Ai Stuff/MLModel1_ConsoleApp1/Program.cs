using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MLModel1_ConsoleApp1
{
    using System.IO.Ports;
    class Program
    {
        static void Main(string[] args)
        {

            // ai info. for every 100 peices of data = 1min of training
            while (true)
            {
                string CHUNGUSINPUT = Console.ReadLine();
                // Create single instance of sample data from first line of dataset for model input
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
            Console.WriteLine("Kill me soon");
        }
    }
}
