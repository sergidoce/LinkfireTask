using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMicroservice.Controllers
{
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
