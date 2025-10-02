using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecijalnaVozilaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaSpecijalnaVozila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaSpecijalnaVozila()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalnaVozila());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSpecijalnoVozilo/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSpecijalnoVozilo(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalnoVozilo(RegOznaka));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSpecijalnoVozilo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajSpecijalnoVozilo([FromBody] SpecijalnaVozilaAddView s)
        {
            try
            {
                await DataProvider.DodajSpecijalnoVozilo(s);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSpecijalnoVozilo/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniSpecijalnoVozilo(string Registarska_Oznaka, [FromBody] SpecijalnaVozilaChangeView s)
        {
            try
            {
                await DataProvider.IzmeniSpecijalnaVozila(s, Registarska_Oznaka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiSpecijalnoVozilo/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiSpecijalnoVozilo(string Registarska_Oznaka)
        {
            try
            {
                await DataProvider.ObrisiSpecijalnoVozilo(Registarska_Oznaka);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
