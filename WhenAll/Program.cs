using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WhenAll.Interfaces;
using WhenAll.Services;

namespace WhenAll
{
    class Program
    {
        static async Task Main()
        {
            var stopwatch = Stopwatch.StartNew();
            await Test();
            Console.WriteLine($"Done in: {stopwatch.ElapsedMilliseconds}ms");            

            stopwatch.Restart();
            await ParallelTest();
            Console.WriteLine($"Parallel done in {stopwatch.ElapsedMilliseconds}ms");

            Console.ReadLine();
        }

        public static async Task Test()
        {
            var pingTasks = new List<IPing>()
            {
                new WorkingPing(),
                new WorkingPing(),
                new WorkingPing(),
                new WorkingPing()
            };

            var pingResult = new List<bool>();

            foreach (IPing ping in pingTasks)
            {
                pingResult.Add(await ping.Ping());
            }
        }

        public static async Task ParallelTest()
        {
            var pingTasks = new List<IPing>()
            {
                new WorkingPing(),
                new BrokenPing(),
                new WorkingPing(),
                new BrokenPing()
            };

            var pingResult = new List<bool>();

            //buffering your call
            var tasks = pingTasks.Select(p => BufferCall(p));

            var completedPings = await Task.WhenAll(tasks);
            foreach (bool ping in completedPings)
            {
                pingResult.Add(ping);
            }
        }


        private static async Task<bool> BufferCall(IPing ping)
        {
            try
            {
                return await ping.Ping();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; //or whatever default
            }
        }
    }
}
