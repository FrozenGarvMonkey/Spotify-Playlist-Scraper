namespace SpotifyPlaylistScraper.Services {
    public interface ISpotifyServiceClass {
        Task<string> GetToken(string clientID, string clientSecret);
    }
}
