using Engine.Network;
using Engine.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EngineTets.Networking
{
    class TransferTest
    {
        public Server Server { get; private set; }
        public Client Client { get; private set; }

        [SetUp]
        public void Setup()
        {
            Parameters.IpAddress = IPAddress.Loopback;
            Server = new Server();
            Client = new Client();
            Client.Connect(Parameters.IpAddress);
        }

        [Test]
        public void Test1()
        {
            Client.PlaceBlock(0, 0, BlockType.DiamondOre);
            var response = Server.PlaceBlock();
            Assert.AreEqual(0, response.RelX);
            Assert.AreEqual(0, response.RelY);

            Client.PlaceBlock(5, 10, BlockType.DiamondOre);
            response = Server.PlaceBlock();
            Assert.AreEqual(5, response.RelX);
            Assert.AreEqual(10, response.RelY);
        }
    }
}
