using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrijavaController : ControllerBase
    {

        [HttpGet]
        [Route("VratiPrijave")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> VratiPrijave()
        {
            try
            {
                 return new JsonResult(await DataProvider.VratiPrijave());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPrijavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajPrijavu([FromBody] PrijavaAddView P)
        {
            try
            {
                await DataProvider.DodajPrijavu(P);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniPrijavu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniPrijavu([FromBody] PrijavaAddView p, int Id) 
        {
            try
            {
                await DataProvider.IzmeniPrijavu(p,Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiPrijavu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObrisiPrijavu(int Id)
        {
            try
            {
                await DataProvider.ObrisiPrijavu(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
