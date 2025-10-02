using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervencijaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiIntervencije")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> VratiIntervencije()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiIntervencije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajIntervenciju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajIntervenciju([FromBody] IntervencijaBasicView P)
        {
            try
            {
                await DataProvider.DodajIntervenciju(P);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniIntervenciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniIntervenciju([FromBody] IntervencijaBasicView p, int Id)
        {
            try
            {
                await DataProvider.IzmeniIntervenciju(p, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiIntervenciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObrisiIntervenciju(int Id)
        {
            try
            {
                await DataProvider.ObrisiIntervenciju(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet]
        [Route("GetVozilaKojaSuUcestvovala/{IdIntervencije}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVozila(int IdIntervencije)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvovanjaVozilaUIntervencijama(IdIntervencije));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetSvaUcestvovanjaUIntervenciji/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSvaUcestvovanja(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvaUcestvovanjaUIntervenciji(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
