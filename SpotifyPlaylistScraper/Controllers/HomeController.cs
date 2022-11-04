using Microsoft.AspNetCore.Mvc;
using SpotifyPlaylistScraper.Models;
using SpotifyPlaylistScraper.Services;
using System.Diagnostics;

namespace SpotifyPlaylistScraper.Controllers {
    public class HomeController : Controller {
        private readonly ISpotifyServiceClass _spotifyService;
        private readonly IConfiguration _configuration;

        public HomeController(ISpotifyServiceClass spotifyService, IConfiguration configuration) {
            _spotifyService = spotifyService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index() {
            try {
                var token = await _spotifyService.GetToken(_configuration["Spotify:ClientID"], _configuration["Spotify:ClientSecret"]);

            }catch (Exception ex) {
                Debug.Write(ex);
            }

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}