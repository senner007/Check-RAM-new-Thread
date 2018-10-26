using System;
using System.Collections;
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
            var t = new Thread(() => TimerLoop());
            t.Start();

            System.Console.WriteLine("Processing LINQ");
            System.Console.WriteLine(".....................................");
            var createArray = CreateArray();
            System.Console.WriteLine( "Done!");
            System.Console.WriteLine( createArray.Length  );

            t.Join(); // See this answer : http://stackoverflow.com/a/14131739/4546874
        }
        public static void TimerLoop() 
        {
            // https://stackoverflow.com/questions/13019433/calling-a-method-every-x-minutes
            new System.Threading.Timer((e) =>
            {
                    PerformanceInfo.GetInfo();
                    System.Console.WriteLine(".....................................");
                  
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        public static Array CreateArray() 
        {
            Random _rand = new Random();
            return Enumerable.Range(0, 100000000).Select(r => _rand.Next(0, 100 + 1)).ToArray();
        }
        
    }
}
