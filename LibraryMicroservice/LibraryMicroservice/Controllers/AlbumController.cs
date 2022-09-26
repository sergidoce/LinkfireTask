using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMicroservice.Controllers
{

    // The Albums Controller gets the requests to find albums using external API's 

    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private IAlbumService _albumService;

        public AlbumController(ILogger<AlbumController> logger, IAlbumService albumService)
        {
            _logger = logger;
            _albumService = albumService;
        }

        // I know it is a bad practice to use verbs in REST endpoints, but I thought using simply the GET terminology would
        // be confusing because we don't get or find albums in our own storage, we use external providers. Also this method can
        // return no result.
        [HttpGet]
        [Route("/find")]
        public async Task<IActionResult> SearchForAlbum([FromQuery] string? name, [FromQuery] string? artist)
        {
            if (name == null && artist == null)
                return BadRequest("You have to indicate at least the name or the artist");

            List<AlbumDTO> albums = await _albumService.FindAlbums(name, artist);
            return Ok(albums);
        }
    }
}
