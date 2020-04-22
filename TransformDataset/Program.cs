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
                .Where(x => x.Length > 12)
                .Select(arr => new[] { arr[1], arr[12] })
                .Select(sel => string.Join(',', sel));
            await File.WriteAllLinesAsync("transformed-dataset.txt", transformed);
        }
    }
}
