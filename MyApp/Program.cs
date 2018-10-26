using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace MyApp
{
    class Program
    {
      static void Main()
        {
            //https://stackoverflow.com/questions/35714547/c-sharp-console-application-run-for-loop-while-not-disturbing-rest-of-exec
            var t = new Thread(() => ExecuteForLoop());
            t.Start();
            var createArray = CreateArray();

            int[] CreateArray()
            {
                Random _rand = new Random();
                return Enumerable.Range(0, 100000000).Select(r => _rand.Next(0, 100 + 1)).ToArray();
            }
          
            System.Console.WriteLine( "Done!");
            System.Console.WriteLine( createArray.Length  );
            t.Join(); // See this answer : http://stackoverflow.com/a/14131739/4546874
        }
        public static void ExecuteForLoop() 
        {
            // https://stackoverflow.com/questions/13019433/calling-a-method-every-x-minutes
            System.Console.Write("Processing LINQ");

            new System.Threading.Timer((e) =>
            {
                    Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
                    Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
                    decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
                    decimal percentOccupied = 100 - percentFree;
                    Console.WriteLine("Available Physical Memory (MiB) " + phav.ToString());
                    Console.WriteLine("Total Memory (MiB) " + tot.ToString());
                    Console.WriteLine("Free (%) " + percentFree.ToString());
                    Console.WriteLine("Occupied (%) " + percentOccupied.ToString());
                    System.Console.WriteLine(".....................................");
                  
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        
    }
}
