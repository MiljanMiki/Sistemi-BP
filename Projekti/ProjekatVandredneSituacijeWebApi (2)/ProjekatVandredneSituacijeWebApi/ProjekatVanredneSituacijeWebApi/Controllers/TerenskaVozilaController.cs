using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerenskaVozilaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSveKamione")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSveKamione()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiKamione());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSveDzipove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSveDzipove()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiDzipove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiKamion/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiKamion(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiKamion(RegOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiDzip/{RegOznaka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiDzip(string RegOznaka)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiDzip(RegOznaka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKamion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajKamion([FromBody] KamioniAddView s)
        {
            try
            {
                await DataProvider.DodajKamion(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDzip")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajDzip([FromBody] DzipoviAddView dz)
        {
            try
            {
                await DataProvider.DodajDzip(dz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniKamion/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniKamion(string Registarska_Oznaka, [FromBody] KamioniChangeView  s)
        {
            try
            {
                await DataProvider.IzmeniKamion(s, Registarska_Oznaka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniDzip/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniDzip(string Registarska_Oznaka, [FromBody] DzipoviChangeView s)
        {
            try
            {
                await DataProvider.IzmeniDzip(s, Registarska_Oznaka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiKamion/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiKamion(string Registarska_Oznaka)
        {
            try
            {
                await DataProvider.ObrisiKamion(Registarska_Oznaka);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiDzip/{Registarska_Oznaka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiDzip(string Registarska_Oznaka)
        {
            try
            {
                await DataProvider.ObrisiDzip(Registarska_Oznaka);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
