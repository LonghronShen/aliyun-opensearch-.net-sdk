﻿using System.Collections.Generic;
using System.Collections.Specialized;
using AliCloudOpenSearch.com.API;
using Newtonsoft.Json.Linq;

namespace AliCloudAPITest
{
    internal class CloudsearchApiMock : CloudsearchApi
    {
        public CloudsearchApiMock(string clientId, string clientSecret, string host = null, int mode = 0,
            string signatureMethod = "HMAC-SHA1",
            string signatureVersion = "1.0", int requestTimeout = 10000, bool debug = false)
            : base(clientId, clientSecret, host, mode, signatureMethod,
                signatureVersion, requestTimeout, debug)
        {
        }

        protected override JObject requestByWebrequest(string method, string url, Dictionary<string, object> parameters,
            NameValueCollection httpOptions = null)
        {
            var args = BuildParams(parameters);

            url += "?" + args;
            args = string.Empty;

            var resultJObject = new JObject();
            resultJObject["rawResponse"] = url;

            return resultJObject;
        }
    }
}