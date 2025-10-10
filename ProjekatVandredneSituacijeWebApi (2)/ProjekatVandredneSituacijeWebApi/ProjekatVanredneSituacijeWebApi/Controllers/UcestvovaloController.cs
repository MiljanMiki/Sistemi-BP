using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcestvovaloController : ControllerBase
    {
        [HttpPost]
        [Route("DodajUcestvovanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajUcestvovanje([FromBody] UcestvovaloAddView s)
        {
            try
            {
                await DataProvider.DodajUcestvovanje(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniUcestvovalo/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IzmeniUcestvovalo([FromBody] UcestvovaloAddView s, int Id)
        {
            try
            {
                await DataProvider.IzmeniUcestvovanje(s, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiUcestvovalo/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObrisiUcestvovovalo(int Id)
        {
            try
            {
                await DataProvider.ObrisiUcestvovanje(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSvaUcestvovanja(Intervencija+Vozila)")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSveUcestvovanja()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvovanja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiUcestvovanje/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiUcestvovanja(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvovanje(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
