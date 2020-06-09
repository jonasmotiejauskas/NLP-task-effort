using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TransformDataset
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rawDataset = (await File.ReadAllTextAsync("raw-dataset.txt")).Split('\n');

            var transformed = rawDataset.Select(full => full.Split(','))
                .Where(x => x.Length > 12)
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                .Select(x => (double.Parse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture),
                new string(x[1].ToLowerInvariant().Trim('"').Trim('\t')
                .Where(c => !char.IsPunctuation(c)).ToArray())
                )).ToArray();

            var engstopwords = StopWord.StopWords.GetStopWords("en");
            var transformedClean = transformed;
            foreach (var stopword in engstopwords)
            {
                transformedClean = transformedClean.Select(x =>
                {
                    var arr = x.Item2.Split(' ');
                    return (x.Item1, string.Join(' ', arr.Where(y => !y.Equals(stopword))));
                }).ToArray();
            }
            transformedClean = transformedClean.Where(x => !string.IsNullOrWhiteSpace(x.Item2)).ToArray();
            Array.Sort(transformedClean);
            var ab = transformedClean.Count() / 3;
            var bc = ab * 2;
            var classes = transformedClean.Select(t =>
            {
                if (t.Item1 <= transformedClean[ab].Item1) return ("0", t.Item2);
                if (t.Item1 <= transformedClean[bc].Item1) return ("1", t.Item2);
                else return ("2", t.Item2);
            });

            await File.WriteAllLinesAsync("D5.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        } 
    } 
}