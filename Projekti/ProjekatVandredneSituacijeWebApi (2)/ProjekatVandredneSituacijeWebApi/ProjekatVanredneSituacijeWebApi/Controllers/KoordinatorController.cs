using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoordinatorController : ControllerBase
    {
        [HttpGet]
        [Route("GetSviKoordinatori")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Koordinatori()
        {
            try
            {
                 return new JsonResult(await DataProvider.VratiKordinatora());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("GetKoordinator/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetKoordintor(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiKordinator(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKoordinatora")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DodajKoordinatora([FromBody] KordinatorView a)
        {
            try
            {
                await DataProvider.DodajKordinatora(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniKoordinatora/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniKoordinatora([FromBody] KordinatorChangeView k,string JMBG)
        {
            try
            {
                await DataProvider.IzmeniKordinatora(k, JMBG);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiKoordinatora/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiKoordiantora(string JMBG)
        {
            try
            {
                await DataProvider.ObrisiAnaliticara(JMBG);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PrikaziSpecijalizaciju/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetSpecijalizacijeKoordinatora(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalizacijeKoordinatora(JMBG));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSpecijalizaciju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> DodajSpecijalizacijuKoordinatoru([FromBody] SpecijalizacijaAddView e)
        {
            try
            {
                await DataProvider.DodajSpecijalizaciju(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSpecijalizaciju/{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniSpecijalizaciju( [FromBody] SpecijalizacijaAddView e, int Id)
        {
            try
            {
                await DataProvider.IzmeniSpecijalizaciju(e,Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiSpecijalizaciju/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiSpecijalizaciju(int id)
        {
            try
            {
                await DataProvider.ObrisiSpecijalizaciju(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }


        }

        [HttpGet]
        [Route("GetSveSpecijalizacije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Specijalizacije()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalizacije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
