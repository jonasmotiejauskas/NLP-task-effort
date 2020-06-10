using Microsoft.ML.Data;

namespace MLNETML.Model
{
    public class ModelInput
    {
        [ColumnName("taskeffortclass"), LoadColumn(0)]
        public float TaskEffortClass { get; set; }


        [ColumnName("summary"), LoadColumn(1)]
        public string Summary { get; set; }


    }
}
