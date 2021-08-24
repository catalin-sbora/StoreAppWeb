using StoreAppWeb.API.Client.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.API.Client
{
    public class APIClient<T>
    {
        protected HttpClient httpClient;
        public string EndpointBase { get; set; }
        public APIClient(HttpClient httpClient)
        {           
            this.httpClient = httpClient;
        }
        public async Task<List<T>> GetAll()
        {
            var response = await httpClient.GetAsync($"{EndpointBase}");
            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        public async Task<T> GetById(string id)
        {
            var response = await httpClient.GetAsync($"{EndpointBase}/{id}");
            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> AddItem(T itemToAdd)
        {
            var response = await httpClient.PostAsJsonAsync($"{EndpointBase}", itemToAdd);
            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public async Task<T> UpdateItem(string id, T itemToUpdate)
        {
            var response = await httpClient.PutAsJsonAsync($"{EndpointBase}/{id}", itemToUpdate);
            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteItem(string id)
        {
            var response = await httpClient.DeleteAsync($"{EndpointBase}/{id}");
            await response.EnsureSuccessStatusCodeAsync();
        }
    }
}
