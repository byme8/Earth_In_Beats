using Earth_In_Beats.WebService.TestApp.PlayerService;
using System;

namespace Earth_In_Beats.WebService.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var webService = new WebService();
            webService.SetLocation(getLatidute(), getLongitude());
            webService.Play("Master", "Metallica");

            foreach (var device in webService.GetOnlineDevices())
            {
                Console.WriteLine($"Device with ID: \"{device.PublicKey}\" is online.");
            }

            webService.Stop();
            webService.Dispose();
        }

        private static double getLongitude()
        {
            return 123;
        }

        private static double getLatidute()
        {
            return 121;
        }
    }
}
