using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Api_Spotify.Models;
using Web_Api_Spotify.Services;

namespace Web_Api_Spotify.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(
            ISpotifyAccountService spotifyAccountService,
            IConfiguration configuration,
            ISpotifyService spotifyService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

            public async Task<IActionResult> Index()
        {
            var newReleases = await GetReleases();

            return View(newReleases);
        }

        private async Task<IEnumerable<Release>> GetReleases()
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(
                    _configuration["Spotify:ClientId"],
                    _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotifyService.GetNewReleases("US", 20, token);

                return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Release>();

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
