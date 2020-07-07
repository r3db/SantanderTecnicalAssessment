using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SantanderTecnicalAssessment
{
    // Todo: Versioning!
    internal static class Program
    {
        private static async Task Main()
        {
            var api = new HackerNewsApi();

            await MeasureElapsedTime(async () =>
            {
                foreach (var item in await api.GetBestStoriesOrderedByScore())
                {
                    Console.WriteLine(item.PostedBy);
                }
            });

            Console.WriteLine("---");

            await MeasureElapsedTime(async () =>
            {
                foreach (var item in await api.GetBestStoriesOrderedByScore())
                {
                    Console.WriteLine(item.PostedBy);
                }
            });

            Console.WriteLine("Done!");
        }

        private static async Task MeasureElapsedTime(Func<Task> action)
        {
            var sw = Stopwatch.StartNew();
            await action();
            sw.Stop();
            Console.WriteLine("Action completed in: {0:F2}s, {1}ms", sw.Elapsed.TotalSeconds, sw.ElapsedMilliseconds);
        }
    }
}