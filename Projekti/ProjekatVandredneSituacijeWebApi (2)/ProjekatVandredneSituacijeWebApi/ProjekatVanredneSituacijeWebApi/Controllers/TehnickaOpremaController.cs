using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TehnickaOpremaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvuTehnickuOpremu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvuTehnickuOpremu()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiTehnickuZastitu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiTehnickuOpremu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiTehnickuOpremu(string Serijski_Broj)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiTehnickuOpremu(Serijski_Broj));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("DodajTehnickuOpremu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajTehnickuOpremu([FromBody] TehnickaOpremaAddView t)
        {
            try
            {
                await DataProvider.DodajTehnickuOpremu(t);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniTehnickuOpremu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniTehnickuOpremu(string Serijski_Broj, [FromBody] TehnickaOpremaChangeView t)
        {
            try
            {
                await DataProvider.IzmeniTehnickuOpremu(t, Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiTehnickuOpremu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiTehnickuOpremu(string Serijski_Broj)
        {
            try
            {
                await DataProvider.ObrisiTehnickuOpremu(Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

