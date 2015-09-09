using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace BreezePerfTester
{
    public class Tester
    {
        public int Times { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
        private TimeSpan _slowest { get; set; }
      
        public void Start()
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", AccessToken);
                var stopwatch = new Stopwatch();

                for (var i = 1; i <= Times; i++)
                {
                    stopwatch.Start();
                    webClient.DownloadString(Url);
                    stopwatch.Stop();

                    var elapsed = stopwatch.Elapsed;

                    if (elapsed > _slowest) _slowest = elapsed;
                            
                    Console.WriteLine(string.Format("Request {0}: {1}", i, elapsed));

                    stopwatch.Reset();
                }

                Console.WriteLine("Slowest request: " + _slowest);
            }
        }
    }
}
