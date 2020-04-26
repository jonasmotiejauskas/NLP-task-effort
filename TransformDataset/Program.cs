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
            Directory.SetCurrentDirectory("..\\..\\..\\..\\.");
            var raw = (await File.ReadAllTextAsync("raw-dataset.txt")).Split('\n');
            var transformed = raw.Select(full => full.Split(','))
                // filter empty lines
                .Where(x => x.Length > 12)
                // format label and take 1 feature
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out double _))
                .Select(arr => new[] {!double.TryParse(arr[12],NumberStyles.Any, CultureInfo.InvariantCulture, out var number) ? arr[12] :
                    number <= 3 ? "0" : number <= 12 ? "1" : number <= 20 ? "2" : "3", arr[1].ToLowerInvariant().Trim('"').Trim('\t') })
                // join back to string
                .Select(sel => string.Join('\t', sel)).Distinct();
            await File.WriteAllLinesAsync("transformed-dataset-4.txt", transformed);
        }
    }
}
