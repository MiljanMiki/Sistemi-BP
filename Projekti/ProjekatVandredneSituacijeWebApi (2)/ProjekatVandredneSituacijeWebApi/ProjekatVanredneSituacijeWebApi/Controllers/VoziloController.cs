using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;
using VanrednaSituacijaLibrary.Entiteti;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaVozila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaVozila()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvaVozila());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSvaDodeljivanja/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaDodeljivanja(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiDodeljivanjaVozila(RegOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiUcestvovanje/{IdIntervencije}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaUcestvovanja(int IdIntervencije)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvovanjaVozilaU(IdIntervencije));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpGet]
        [Route("VratiSvaUcestvovanjeVozila/{regOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaUcestvovanjaVozila(string regOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiUcestvovanjeVozilaUKojimajeUcestvovalo(regOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("VratiSveServiseVozila/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSveServise(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiServiseVozila(RegOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSveServise")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSveServise()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiServise());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajServis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajServis([FromBody] ServisiAddView s)
        {
            try
            {
                await DataProvider.DodajServis(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpPut]
        [Route("IzmeniServis/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniServis([FromBody] ServisiAddView s, int Id)
        {
            try
            {
                await DataProvider.IzmeniServis(s, Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiServis/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiServis(int Id)
        {
            try
            {
                await DataProvider.ObrisiServis(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
