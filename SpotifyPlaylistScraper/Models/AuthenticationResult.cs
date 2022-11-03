namespace SpotifyPlaylistScraper.Models {
    public class AuthenticationResult {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiryTime { get; set; }

    }
}
