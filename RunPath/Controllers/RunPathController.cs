using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RunPath.Controllers
{
    using RunPath.Models;
    using RunPath.Services;

    [Route("runpath/[controller]")]
    [ApiController]
    public class RunPathController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public RunPathController( IPhotoService photoService)
        {
            _photoService = photoService;
        }


        [HttpGet]
        public async Task<ActionResult<RunPathApiResponse<IEnumerable<RunPathAlbum>>>> Get(int? userId = null)
        {
            var photos = await _photoService.GetRunPathPhotos(userId);

            return new OkObjectResult(photos);
        }
    }
}
