using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;

namespace Picture.Service
{
    public class PictureService : IPictureService
    {
        public PictureService()
        {
        }

        public async Task<IEnumerable<Album>> GetAllPhotosByUrlAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            var jsonAlbums = await response.Content.ReadAsStringAsync();
            var modelAlbums = JsonConvert.DeserializeObject<IEnumerable<Album>>(jsonAlbums);

            return modelAlbums;
        }

        public async Task<IEnumerable<Photo>> GetDetailsPhotoByUrlAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            var jsonAlbums = await response.Content.ReadAsStringAsync();
            var modelPhotos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(jsonAlbums);
            return modelPhotos;
        }
    }
}