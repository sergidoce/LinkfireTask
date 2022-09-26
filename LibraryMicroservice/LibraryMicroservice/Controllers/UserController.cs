using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMicroservice.Controllers
{
    
    //The User Controller gets the requests to interact with a user's album library.
     
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        //I inject the dependencies for the controller using the Dependency Injection.
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("{user_id}/albums")]
        public IActionResult AddAlbumToLibrary([FromRoute] int user_id, [FromBody] AlbumDTO albumDTO)
        {
            var album = _userService.AddAlbumToLibrary(user_id, albumDTO);

            if(album == null)
                return NotFound("User not found");

            return Ok();
        }

        [HttpDelete]
        [Route("{user_id}/albums/{album_id}")]
        public IActionResult RemoveAlbumFromLibrary([FromRoute] int user_id, [FromRoute] string album_id)
        {
            var result = _userService.RemoveAlbumFromLibrary(user_id, album_id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
