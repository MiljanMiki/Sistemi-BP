using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanrednaSituacijaController : ControllerBase
    {

        [HttpGet]
        [Route("PrikaziVanredneSituacije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiVanredneSituacije()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiVanredneSituacije());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        [HttpPost]
        [Route("DodajVanrednuSituaciju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> DodajVanrednuSituaciju([FromBody] VanrednaSituacijaAddView v)
        {
            try
            {
                await DataProvider.DodajVanrednuSituaciju(v);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut]
        [Route("IzmeniVanrednuSituaciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> IzmeniVanrednuSituaciju(int Id, [FromBody] VanrednaSituacijaAddView v)
        {
            try
            {
                await DataProvider.IzmeniVanrednuSituaciju(v, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete]
        [Route("ObrisiVanrednuSituaciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> ObrisiVanrednuSituaciju(int Id)
        {
            try
            {
                await DataProvider.obrisiVanrednuSituaciju(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiVanrednuSituaciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiVanrednuSituaciju(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiVanrednuSituaciju(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet]
        [Route("VratiSveSluzbeUVanrednojSituaciji/{IdVs}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSaranje(int IdVs)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSveSluzbeKojeSaradjujuSaVS(IdVs));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet]
        [Route("VratiSveUcestvovanjaUVanrednojSituaciji/{IdVs}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiUcestvovanja(int IdVs)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvaUcestvovanjaUVanrednojSituaciji(IdVs));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
