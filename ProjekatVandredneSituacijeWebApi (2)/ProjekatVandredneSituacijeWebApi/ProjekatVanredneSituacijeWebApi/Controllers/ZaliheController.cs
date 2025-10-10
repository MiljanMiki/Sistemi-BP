using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaliheController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSveZalihe")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSveZalihe()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiZalihe());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZalihe/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiZalihe(string Serijski_Broj)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiZalihe(Serijski_Broj));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("DodajNoveZalihe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajZalihe([FromBody]ZaliheAddView z) 
        {
            try
            {
                await DataProvider.DodajZalihe(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniZalihe/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniZalihe(string Serijski_Broj, [FromBody]ZaliheChangeView z)
        {
            try
            {
                await DataProvider.IzmeniZalihe(z, Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZalihe/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiZalihe(string Serijski_Broj)
        {
            try
            {
                await DataProvider.ObrisiZalihe(Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
