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
                .Select(arr => new[] { arr[1], !double.TryParse(arr[12],System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out var number) ? arr[12] :
                    number <= 5 ? "0" : number <= 15 ? "1" : "2"})
                // join back to string
                .Select(sel => string.Join(',', sel));
            await File.WriteAllLinesAsync("transformed-dataset.txt", transformed);
        }
    }
}
