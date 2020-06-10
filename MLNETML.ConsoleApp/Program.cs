using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using MLNETML.Model;

namespace MLNETML.ConsoleApp
{
    class Program
    {
        private const string DATA_FILEPATH = @"";

        static void Main(string[] args)
        {
            ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);

            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Col0 with predicted Col0 from sample data...\n\n");
            Console.WriteLine($"Summary: {sampleData.Summary}");
            Console.WriteLine($"\n\nActual TaskEffortClass: {sampleData.TaskEffortClass} \nPredicted TaskEffortClass value {predictionResult.Prediction} \nPredicted TaskEffortClass scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }

        private static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            MLContext mlContext = new MLContext();

            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: '\t',
                                            allowQuoting: true,
                                            allowSparse: false);

            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }
    }
}
