using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperativniRadnikController : ControllerBase
    {
        [HttpGet]
        [Route("GetSviOperativniRadnici")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> OperativniRadnici()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOperativneRadnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("GetOperativniRadnik/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetOperativniRadnik(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOperativnogRadnika(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajOperativnogRadnika")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DodajOperativnogRadnika([FromBody] OperativniRadnikAddView a)
        {
            try
            {
                await DataProvider.DodajOperativnogRadnik(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniOperativnogRadnika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniOperativnogRadnika([FromBody] OperativniRadnikChangeView k, string JMBG)
        {
            try
            {
                await DataProvider.IzmeniOperativnog(k,JMBG);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiOperativnogRadnika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiOperativnogRadnika(string JMBG)
        {
            try
            {
                await DataProvider.ObrisiOperativnogRadnika(JMBG);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PrikaziSertifikate/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> PrikaziSertifikate(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSertifikateZaposlenog(JMBG));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSertifikat")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> DodajSertifikat([FromBody] SertifikatView e)
        {
            try
            {
                await DataProvider.DodajSertifikat(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSertifikat")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniSertifikat([FromBody] SertifikatView e)
        {
            try
            {
                await DataProvider.IzmeniSertifikat(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiSertifikat/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiSertifikat([FromBody] SertifikatView s)
        {
            try
            {
                await DataProvider.ObrisiSertifikat(s);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }

        [HttpGet]
        [Route("GetSviSertifikati")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Sertifikati()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSertifikate());
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



    }
}
