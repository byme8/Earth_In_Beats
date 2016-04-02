using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Earth_In_Beats.WebService.Integration.PlayerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Earth_In_Beats.WebService.IntegrationTests
{
    [TestClass]
    public class PlayerService
    {
        class Constans
        {
            public const string CorrectDeviceKey = "some_correct_device_key";
            public const string WrongDeviceKey = "some_wrong_device_key";
        }

        [TestMethod]
        public void Connect_CorrectDeviceKey_CorrectDeviceContext()
        {
            var client = new PlayerServiceClient();

            var device = client.ConnectAsync(
                new ConnectRequest
                {
                    DeviceKey = Constans.CorrectDeviceKey
                }).Result;

            Assert.IsTrue(device.Success, "Sent correct device key, but request is not success.");
        }

        [TestMethod]
        public void Connect_WrongDeviceKey_MessageWithError()
        {
            var client = new PlayerServiceClient();

            var responce = client.ConnectAsync(
                new ConnectRequest
                {
                    DeviceKey = Constans.WrongDeviceKey
                }).Result;

            Assert.IsFalse(responce.Success, "Sent wrong device key, but request to service is success.");
        }

        [TestMethod]
        public void UpdateLocation_CorrectLocation_Success()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(
                new ConnectRequest
                {
                    DeviceKey = Constans.CorrectDeviceKey
                }).
                Result;

            var updateResponce = client.UpdateAsync(
                new UpdateRequst
                {
                    Id = connectResponce.Id,
                    Latitude = 1,
                    Longitude = 1
                }).
                Result;

            Assert.IsTrue(updateResponce.Device.Latitude == 1 || updateResponce.Device.Longitude == 1, 
                "Send correct device id and location, but request is not success.");
        }

        [TestMethod]
        public void UpdateLocation_WrongLocation_Fail()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(
                new ConnectRequest
                {
                    DeviceKey = Constans.CorrectDeviceKey
                }).
                Result;

            var updateResponce = client.UpdateAsync(
                new UpdateRequst
                {
                    Id = connectResponce.Id,
                    Latitude = 1,
                    Longitude = 1
                }).
                Result;

            Assert.IsFalse(updateResponce.Success,
                "Send wrong location, but service is success.");
        }

        [TestMethod]
        public void Play_CorrectId_Success()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(new ConnectRequest { DeviceKey = Constans.CorrectDeviceKey }).Result;

            var updateResponce = client.UpdateAsync(new UpdateRequst { Id = connectResponce.Id, Latitude = 1, Longitude = 1 }).Result;

            var playResponce = client.PlayAsync(new PlayRequest { Id = connectResponce.Id, Artist = "Lol", Title = "loL"}).Result;

            Assert.IsTrue(playResponce.Success, "Sent correct device id, but request to web service is not success.");
        }

        [TestMethod]
        public void Play_WrongId_Fail()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(new ConnectRequest { DeviceKey = Constans.WrongDeviceKey }).Result;

            var updateResponce = client.UpdateAsync(new UpdateRequst { Id = connectResponce.Id, Latitude = 1, Longitude = 1 }).Result;

            var playResponce = client.PlayAsync(new PlayRequest { Id = connectResponce.Id, Artist = "Lol", Title = "loL" }).Result;

            Assert.IsFalse(playResponce.Success, "Sent wrong device id, but request to web server is success.");
        }

        [TestMethod]
        public void Stop_CorrectId_Success()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(new ConnectRequest { DeviceKey = Constans.CorrectDeviceKey }).Result;

            var updateResponce = client.UpdateAsync(new UpdateRequst { Id = connectResponce.Id, Latitude = 1, Longitude = 1 }).Result;

            var playResponce = client.PlayAsync(new PlayRequest { Id = connectResponce.Id, Artist = "Lol", Title = "loL" }).Result;

            var stopResponce = client.StopAsync(new StopRequest { Id = connectResponce.Id }).Result;

            Assert.IsTrue(stopResponce.Success, "Sent correct device id, but request to web service is not success.");
        }

        [TestMethod]
        public void Stop_WrognId_Fail()
        {
            var client = new PlayerServiceClient();

            var connectResponce = client.ConnectAsync(new ConnectRequest { DeviceKey = Constans.CorrectDeviceKey }).Result;

            var updateResponce = client.UpdateAsync(new UpdateRequst { Id = connectResponce.Id, Latitude = 1, Longitude = 1 }).Result;

            var playResponce = client.PlayAsync(new PlayRequest { Id = connectResponce.Id, Artist = "Lol", Title = "loL" }).Result;

            var stopResponce = client.StopAsync(new StopRequest { Id = connectResponce.Id }).Result;

            Assert.IsFalse(stopResponce.Success, "Sent wrong device id, but request to web server is success.");
        }
    }
}
