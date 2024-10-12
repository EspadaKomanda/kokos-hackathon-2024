using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Sinks.Loki;

namespace DialogService.Logging
{
    public class LokiMatchHttpClient: LokiHttpClient
    {
        public override async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            var r = content.ReadAsStringAsync().Result;

            var result = await base.PostAsync(requestUri, content);
            var body = result.Content.ReadAsStringAsync().Result; //right!

            return result;
        }
    }
}