// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace BERTTestingGroundsML.Model
{
    public class ModelInput
    {
        [ColumnName("Summary"), LoadColumn(0)]
        public string Summary { get; set; }


        [ColumnName("HoursActual"), LoadColumn(1)]
        public string HoursActual { get; set; }


    }
}