using Earth_In_Beats.WebService.TestApp.PlayerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth_In_Beats.WebService.TestApp
{
    public class WebService : IDisposable
    {
        private PlayerServiceClient client;
        private DeviceContextData device;

        public WebService()
        {
            this.client = new PlayerServiceClient();
            this.device = client.Connect();
        }

        public void SetLocation(double newLatitude, double newLongitude)
        {
            device.Latitude = newLatitude;
            device.Longitude = newLongitude;

            device = client.Update(device);
        }

        public void Play(string title, string artist)
        {
            client.Play(device, new TrackData { Title = title, Artist = artist });
        }

        public void Stop()
        {
            client.Stop(device);
        }

        public DeviceData[] GetOnlineDevices()
        {
            return client.Get();
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.Disconnect(device);
                client.Close();
                client = null;
            }
        }
    }
}
