using NDesk.Options;
using System;
using System.Collections.Generic;

namespace BreezePerfTester
{
    class Program
    {
        public static Tester tester;

        static void Main(string[] args)
        {
            tester = new Tester();

            var p = new OptionSet() {
                { "times=",      (int v) => tester.Times = v },
                { "url=",  v => tester.Url = v },
                { "accesstoken=",   v => tester.AccessToken = v }
            };
            

            try {
                List<string> parameters = p.Parse(args);
                tester.Start();
            }
            catch (OptionException e)
            {
                Console.Write("Error: ");
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Done");
        }
    }
}
