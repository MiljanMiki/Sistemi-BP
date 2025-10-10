using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanitetskaVozilaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaSanitetskaVozila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaSanitetskaVozila()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSanitetskaVozila());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSanitetskoVozilo/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSanitetskoVozilo(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSanitetkoVozilo(RegOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSanitetskoVozilo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajSanitetskoVozilo([FromBody] SanitetskaAddView s)
        {
            try
            {
                await DataProvider.DodajSanitetskaVozilo(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSanitetskoVozilo/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniSanitetskoVozilo(string Registarska_Oznaka, [FromBody] SanitetskaChangeView s)
        {
            try
            {
                await DataProvider.IzmeniSanitetskoVozilo(s, Registarska_Oznaka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiSanitetskoVozilo/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiSanitetskoVozilo(string Registarska_Oznaka)
        {
            try
            {
                await DataProvider.ObrisiSanitetskoVozilo(Registarska_Oznaka);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
