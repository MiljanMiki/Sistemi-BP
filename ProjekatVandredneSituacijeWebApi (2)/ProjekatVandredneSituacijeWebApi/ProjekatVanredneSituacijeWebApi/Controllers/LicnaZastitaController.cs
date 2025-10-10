using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicnaZastitaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvuLicnuZastitu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvuLicnuZastitu()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOpremuLicneZastite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiLicnuZastitu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiLicnuZastitu(string Serijski_Broj)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiLicnuZastitu(Serijski_Broj));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("DodajLicnuZastitu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajLicnuZastitu([FromBody] LicnaZastitaAddView l)
        {
            try
            {
                await DataProvider.DodajLicnuZastitu(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniLicnuZastitu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniLicnuZastitu(string Serijski_Broj, [FromBody]LicnaZastitaChangeView l)
        {
            try
            {
                await DataProvider.IzmeniLicnuZastitu(l, Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiLicnuZastitu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiLicnuZastitu(string Serijski_Broj)
        {
            try
            {
                await DataProvider.ObrisiLicnuZastitu(Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

