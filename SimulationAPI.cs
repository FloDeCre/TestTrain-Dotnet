using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimulationAPI
{
    public enum HttpMethodType { Get, Post, Put, Delete }

    public class Simulation<T>
    {
        public string Path { get; }
        public T? Data { get; }

        public Simulation(string path, T data)
        {
            Path = path;
            Data = data;
        }
    }

    public class ApiIntegrationTests
    {
        private readonly HttpClient _httpClient;

        public ApiIntegrationTests()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
        }

        public async Task<Simulation<T>?> SendRequest<T>(string path, T data, HttpMethodType methodType)
        {
            HttpResponseMessage response = await SendHttpRequest(methodType, new Uri(_httpClient.BaseAddress, path), data);
            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                T? responseData = await response.Content.ReadFromJsonAsync<T>();
                return new Simulation<T>(path, responseData!);
            }
            return null;
        }

        public async Task<bool> SendRequestForSuccess(string path, HttpMethodType methodType, object? data = null)
        {
            HttpResponseMessage response = await SendHttpRequest(methodType, new Uri(_httpClient.BaseAddress, path), data);
            return response.IsSuccessStatusCode;
        }

        private async Task<HttpResponseMessage> SendHttpRequest<T>(HttpMethodType methodType, Uri requestUrl, T? data = default)
        {
            return methodType switch
            {
                HttpMethodType.Get => await _httpClient.GetAsync(requestUrl),
                HttpMethodType.Post => await _httpClient.PostAsJsonAsync(requestUrl, data!),
                HttpMethodType.Put => await _httpClient.PutAsJsonAsync(requestUrl, data!),
                HttpMethodType.Delete => await _httpClient.DeleteAsync(requestUrl),
                _ => throw new ArgumentException("Cette Methode HTTP n'existe pas."),
            };
        }
    }
}
