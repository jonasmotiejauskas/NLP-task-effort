using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using MLNETML.Model;

namespace MLNETML.Model
{
    public class ConsumeModel
    {
        public static ModelOutput Predict(ModelInput input)
        {

            MLContext mlContext = new MLContext();

            string modelPath = @"";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            ModelOutput result = predEngine.Predict(input);
            return result;
        }
    }
}
