using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        [HttpGet]
        [Route("GetSviZaposleni")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Zaposleni()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSveZaposlene());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("GetIstorijaZaposlenog/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task <IActionResult> GetIstorijaZaposlenog(string JMBG)
        {
            try
            {
                 return new JsonResult(await DataProvider.VratiIstorijuUZaposlenog(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajIstorijuZaposlenog")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DodajIstoriju([FromBody] Istorija_Uloga_ZaposlenihAddView a)
        {
            try
            {
                await DataProvider.DodajIstorijuUloga(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniIstoriju/{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniIstoriju([FromBody] Istorija_Uloga_ZaposlenihAddView a, int Id)
        {
            try
            {
                await DataProvider.IzmeniIstorijuUloga(a, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiIstoriju/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiIstoriju(int Id)
        {
            try
            {
                await DataProvider.ObrisiIstorijuUloga(Id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
