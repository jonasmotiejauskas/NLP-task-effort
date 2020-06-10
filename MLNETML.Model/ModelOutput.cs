using System;
using Microsoft.ML.Data;

namespace MLNETML.Model
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public Single Prediction { get; set; }
        public float[] Score { get; set; }
    }
}
