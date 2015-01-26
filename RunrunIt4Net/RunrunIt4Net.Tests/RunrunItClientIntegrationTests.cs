using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunrunIt4Net.Entities;

namespace RunrunIt4Net.Tests
{
    [TestClass]
    public class RunrunItClientIntegrationTests
    {
        private const string Appkey = "APP_KEY";
        private const string UserToken = "USER_TOKEN";
        private HttpClientHandler _handler;
        private RunrunIt4NetClient _client;

        [TestInitialize]
        public void Initialize()
        {
            //range
            var _handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true,
                AllowAutoRedirect = true,
                UseProxy = true,
                Proxy = new WebProxy(new Uri(@"ProxyHost:ProxyPort"))
            };
            _handler.Proxy.Credentials = new NetworkCredential("ProxyUser", "ProxyPassword");

            _client = new RunrunIt4NetClient(Appkey, UserToken, _handler);
        }

        [TestMethod]
        public void GetClients()
        {
            //act
            var listClients = _client.Get<Client>();

            //assert
            Assert.IsNotNull(listClients);
            Assert.IsTrue(listClients.Any());
        }

        [TestMethod]
        public void GetClientsById()
        {
            //arrange
            var idFind = 12810;

            //act
            var client = _client.GetById<Client>(idFind);

            //assert
            Assert.IsNotNull(client);
            Assert.IsTrue(client.Id.Equals(idFind));
        }

        [TestMethod]
        public void CreateClient()
        {
            //arrange
            var client = new Client();

            var res = _client.Post(client);

        }

        [TestMethod]
        public void UpdateClient()
        {
        }
    }
}
