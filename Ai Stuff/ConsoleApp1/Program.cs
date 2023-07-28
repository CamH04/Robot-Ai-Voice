using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Col0 = @"Wow... Loved this place.",
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);

        }
    }
}
