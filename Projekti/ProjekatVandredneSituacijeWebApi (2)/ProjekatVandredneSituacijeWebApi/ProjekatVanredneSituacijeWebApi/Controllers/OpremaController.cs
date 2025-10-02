using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpremaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvuOpremu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSvuOpremu()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvuOpremu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
