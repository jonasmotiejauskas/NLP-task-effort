using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TransformDataset
{
    class Program
    {
        static async Task Main()
        {
            var rawDataset = (await File.ReadAllTextAsync("raw-dataset.txt")).Split('\n');
            Task.WaitAll(ConstructD1(rawDataset),
                ConstructD2(rawDataset),
                ConstructD3(rawDataset),
                ConstructD4(rawDataset),
                ConstructD5(rawDataset),
                ConstructD6(rawDataset),
                ConstructD7(rawDataset),
                ConstructD8(rawDataset));
        } 

        static async Task ConstructD1(string [] rawDataset)
        {
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
            var classes = transformed.Select(t =>
            {
                if (t.Item1 <= 5) return ("0", t.Item2);
                if (t.Item1 <= 15) return ("1", t.Item2);
                else return ("2", t.Item2);
            });

            await File.WriteAllLinesAsync("D1.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD2(string[] rawDataset)
        {
            var transformed = rawDataset.Select(full => full.Split(','))
                .Where(x => x.Length > 12)
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                .Select(x => (double.Parse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture),
                new string(x[1].ToLowerInvariant().Trim('"').Trim('\t')
                .Where(c => !char.IsPunctuation(c)).ToArray())
                )).Distinct().ToArray();

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

            var classes = transformed.Select(t =>
            {
                if (t.Item1 <= 5) return ("0", t.Item2);
                if (t.Item1 <= 15) return ("1", t.Item2);
                else return ("2", t.Item2);
            });

            await File.WriteAllLinesAsync("D2.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD3(string[] rawDataset)
        {
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

            var classes = transformed.Select(t =>
            {
                if (t.Item1 <= 3) return ("0", t.Item2);
                if (t.Item1 <= 12) return ("1", t.Item2);
                if (t.Item1 <= 20) return ("2", t.Item2);
                else return ("3", t.Item2);
            });

            await File.WriteAllLinesAsync("D3.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD4(string[] rawDataset)
        {
            var transformed = rawDataset.Select(full => full.Split(','))
                .Where(x => x.Length > 12)
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                .Select(x => (double.Parse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture),
                new string(x[1].ToLowerInvariant().Trim('"').Trim('\t')
                .Where(c => !char.IsPunctuation(c)).ToArray())
                )).Distinct().ToArray();

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

            var classes = transformed.Select(t =>
            {
                if (t.Item1 <= 3) return ("0", t.Item2);
                if (t.Item1 <= 12) return ("1", t.Item2);
                if (t.Item1 <= 20) return ("2", t.Item2);
                else return ("3", t.Item2);
            });

            await File.WriteAllLinesAsync("D4.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD5(string[] rawDataset)
        {
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

        static async Task ConstructD6(string[] rawDataset)
        {
            var transformed = rawDataset.Select(full => full.Split(','))
                .Where(x => x.Length > 12)
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                .Select(x => (double.Parse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture),
                new string(x[1].ToLowerInvariant().Trim('"').Trim('\t')
                .Where(c => !char.IsPunctuation(c)).ToArray())
                )).Distinct().ToArray();
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
            Array.Sort(transformedClean);
            var ab = transformedClean.Count() / 3;
            var bc = ab * 2;
            var classes = transformedClean.Select(t =>
            {
                if (t.Item1 <= transformedClean[ab].Item1) return ("0", t.Item2);
                if (t.Item1 <= transformedClean[bc].Item1) return ("1", t.Item2);
                else return ("2", t.Item2);
            });

            await File.WriteAllLinesAsync("D6.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD7(string[] rawDataset)
        {
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
            Array.Sort(transformedClean);
            var ab = transformedClean.Count() / 4;
            var bc = ab * 2;
            var cd = ab * 3;
            var classes = transformedClean.Select(t =>
            {
                if (t.Item1 <= transformedClean[ab].Item1) return ("0", t.Item2);
                if (t.Item1 <= transformedClean[bc].Item1) return ("1", t.Item2);
                if (t.Item1 <= transformedClean[cd].Item1) return ("2", t.Item2);
                else return ("3", t.Item2);
            });

            await File.WriteAllLinesAsync("D7.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }

        static async Task ConstructD8(string[] rawDataset)
        {
            var transformed = rawDataset.Select(full => full.Split(','))
                .Where(x => x.Length > 12)
                .Where(x => double.TryParse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
                .Select(x => (double.Parse(x[12], NumberStyles.Any, CultureInfo.InvariantCulture),
                new string(x[1].ToLowerInvariant().Trim('"').Trim('\t')
                .Where(c => !char.IsPunctuation(c)).ToArray())
                )).Distinct().ToArray();
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
            Array.Sort(transformedClean);
            var ab = transformedClean.Count() / 4;
            var bc = ab * 2;
            var cd = ab * 3;
            var classes = transformedClean.Select(t =>
            {
                if (t.Item1 <= transformedClean[ab].Item1) return ("0", t.Item2);
                if (t.Item1 <= transformedClean[bc].Item1) return ("1", t.Item2);
                if (t.Item1 <= transformedClean[cd].Item1) return ("2", t.Item2);
                else return ("3", t.Item2);
            });
            await File.WriteAllLinesAsync("D8.txt", classes.Select(t => $"{t.Item1}\t{t.Item2}"));
        }
    } 
}