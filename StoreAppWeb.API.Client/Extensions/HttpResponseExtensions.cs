using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.API.Client.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                var responseContent = message.Content == null
                                      ? ""
                                      : await message.Content.ReadAsStringAsync();
                throw new HttpRequestException($"{message.ReasonPhrase} ");
            }
        }
    }
}
