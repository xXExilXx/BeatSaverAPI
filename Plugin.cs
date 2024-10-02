using BeatSaverAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BeatSaverAPI
{
    public class BeatSaverClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://api.beatsaver.com";

        public BeatSaverClient()
        {
            _client = new HttpClient();
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(_baseUrl + endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        // Maps Endpoints
        public async Task<MapDetail> GetMapById(string id)
        {
            return await GetAsync<MapDetail>($"/maps/id/{id}");
        }

        public async Task<MapDetail[]> GetMapsByIds(string[] ids)
        {
            var idList = string.Join(",", ids);
            return await GetAsync<MapDetail[]>($"/maps/ids/{idList}");
        }

        public async Task<MapDetail> GetMapByHash(string hash)
        {
            return await GetAsync<MapDetail>($"/maps/hash/{hash}");
        }

        public async Task<MapDetail[]> GetMapsByUploader(string uploaderId, int page = 0)
        {
            return await GetAsync<MapDetail[]>($"/maps/uploader/{uploaderId}/{page}");
        }

        public async Task<MapDetail[]> GetLatestMaps(int page = 0)
        {
            return await GetAsync<MapDetail[]>($"/maps/latest?page={page}");
        }

        // Users Endpoints
        public async Task<UserDetail> GetUserById(string id)
        {
            return await GetAsync<UserDetail>($"/users/id/{id}");
        }

        public async Task<UserDetail[]> GetUsersByIds(string[] ids)
        {
            var idList = string.Join(",", ids);
            return await GetAsync<UserDetail[]>($"/users/ids/{idList}");
        }

        public async Task<UserDetail> GetUserByName(string name)
        {
            return await GetAsync<UserDetail>($"/users/name/{name}");
        }

        // Search Endpoints
        public async Task<SearchResponse> SearchMaps(string query, int page = 0)
        {
            return await GetAsync<SearchResponse>($"/search/text/{page}?q={query}");
        }

        // Playlists Endpoints
        public async Task<Playlist[]> GetLatestPlaylists(int page = 0)
        {
            return await GetAsync<Playlist[]>($"/playlists/latest?page={page}");
        }

        public async Task<Playlist> GetPlaylistById(string id, int page = 0)
        {
            return await GetAsync<Playlist>($"/playlists/id/{id}/{page}");
        }
    }
}
