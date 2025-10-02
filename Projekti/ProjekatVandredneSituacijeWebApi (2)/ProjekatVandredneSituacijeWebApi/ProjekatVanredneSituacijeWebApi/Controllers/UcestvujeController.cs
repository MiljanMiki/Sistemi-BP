using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcestvujeController : ControllerBase
    {
        [HttpPost]
        [Route("DodajUcestvovanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajUcestvovanje([FromBody] UcestvujeAddView s)
        {
            try
            {
                await DataProvider.DodajUcestvuje(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniUcestvuje/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IzmeniUcestvuje([FromBody] UcestvujeAddView s, int Id)
        {
            try
            {
                await DataProvider.IzmeniUcestvuje(s, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiUcestvuje/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObrisiUcestvovanje(int Id)
        {
            try
            {
                await DataProvider.ObrisiUcestvuje(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSvaUcestvovanja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSveUcestvovanja()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvaUcestvovanja());
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
        public async Task<IActionResult> VratiUcestvuje(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvuje(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
