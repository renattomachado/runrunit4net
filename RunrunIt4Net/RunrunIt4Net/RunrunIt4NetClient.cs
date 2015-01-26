using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RunrunIt4Net.Attributes;
using RunrunIt4Net.Converter;
using RunrunIt4Net.Entities;

namespace RunrunIt4Net
{
    public class RunrunIt4NetClient : IDisposable
    {
        private const string UrlBase = @"http://secure.runrun.it/api/v1.0/";
        private string _appKey;
        private string _userToken;
        private readonly HttpClientHandler _handler;
        private HttpClient _client;

        protected HttpClient Client
        {
            get
            {
                _client = _client ?? (_client = _handler == null ? new HttpClient() : new HttpClient(_handler, true));
                _client.BaseAddress = new Uri(UrlBase);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Add("App-Key", _appKey);
                _client.DefaultRequestHeaders.Add("User-Token", _userToken);

                return _client;
            }
        }

        public RunrunIt4NetClient(string appKey, string userToken)
        {
            _appKey = appKey;
            _userToken = userToken;
        }

        public RunrunIt4NetClient(string appKey, string userToken, HttpClientHandler handler)
        {
            _appKey = appKey;
            _userToken = userToken;
            _handler = handler;
        }

        #region API Methods

        #region Client

        public IEnumerable<T> Get<T>()
        {
            var retorno = Client.GetStringAsync(typeof(T).Name.ToLower()+"s").Result;
            return JsonConvert.DeserializeObject<IEnumerable<T>>(retorno);
        }

        public T GetById<T>(int id)
        {
            
            var retorno = Client.GetStringAsync(string.Format("{0}/{1}", typeof(T).Name.ToLower() + "s", id)).Result;
            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public bool Post<T>(T obj)
        {
            var jsonSend = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings(){ContractResolver = new RunrunitSerializeEntityResolver(new PostColumnAttribute())});
            
            var result = Client.PostAsync(typeof(T).Name.ToLower(), new StringContent(jsonSend));
            return true;
        }

        #endregion

        #endregion

        public void Dispose()
        {
            Client.Dispose();
        }

        
    }
}