using SpotifyPlaylistScraper.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SpotifyPlaylistScraper.Services {
    public class SpotifyServiceClass : ISpotifyServiceClass {
        
        private readonly HttpClient _httpClient;

        public SpotifyServiceClass(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<string> GetToken(string clientID, string clientSecret) {
            try {
                var req = new HttpRequestMessage(HttpMethod.Post, "token");

                req.Headers.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}"))
                    );

                req.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                    { "grant_type", "client_credentials" }
                });

                var res = await _httpClient.SendAsync(req);

                res.EnsureSuccessStatusCode();

                using var resStream = await res.Content.ReadAsStreamAsync();
                var authResult = await JsonSerializer.DeserializeAsync<AuthenticationResult>(resStream);

                return authResult.AccessToken;
            }
            catch (NotImplementedException ex) {
                throw ex;
            }
        }


    }
}
