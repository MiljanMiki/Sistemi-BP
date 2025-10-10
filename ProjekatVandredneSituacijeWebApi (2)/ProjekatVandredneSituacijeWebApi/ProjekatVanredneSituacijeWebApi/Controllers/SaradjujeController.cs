using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaradjujeController : ControllerBase
    {
        [HttpPost]
        [Route("DodajSaradnju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajSaradnju([FromBody] SaradjujeAddView s)
        {
            try
            {
                await DataProvider.DodajSaradnju(s);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSaradnju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IzmeniSaradnju([FromBody] SaradjujeAddView s, int Id)
        {
            try
            {
                await DataProvider.IzmeniSaradnju(s, Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiSaradnju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObrisiSaradnju(int Id)
        {
            try
            {
                await DataProvider.ObrisiSaradnju(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSveSaradnje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSveSaradnje()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSaradnje());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSaradnju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSaradnju(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSaradnju(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
