using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventnaJedinicaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSveJedinice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VratiSveJedinice()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSveJedinice());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSpecijalneJedinice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSpecijalneJedinice()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalneJedinice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiOpsteJedinice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiOpsteJedinice()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOpstejedinice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("VratiSpecijalnuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSpecijalneJedinicu(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSpecijalnuJedinicu(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiOpstuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSOpstuJedinicu(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOpstuJedinicu(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("DodajSpecijalnuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajSpecijalnuJedinicu([FromBody] SpecijalnaIntervetnaJedinicaBasicView s)
        {
            try
            {
                await DataProvider.DodajSpecijalnuIntervetnuJedinicu(s);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajOpstuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajOpstuJedinicu([FromBody] OpstaInterventnaBasicView s)
        {
            try
            {
                await DataProvider.DodajOpstuIntervetnuJedinicu(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("IzmeniOpstuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult>  IzmeniOpstuInterventnu(int Id, [FromBody] OpstaInterventnaBasicView i)
        {
            try
            {
                await DataProvider.IzmeniOpstuInterventnuJedinicu(i, Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSpecijalnuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniSpecijalnuInterventnu(int Id, [FromBody] SpecijalnaIntervetnaJedinicaBasicView i)
        {
            try
            {
                await DataProvider.izmeniSpecijalnuInterventnuJedinicu(i, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiOpstuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiOpstuJedinicu(int Id)
        {
            try
            {
                await DataProvider.ObrisiOpstuInterventnuJedinicu(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiSpecijalnuJedinicu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiSpecijalnuJedinicu(int Id)
        {
            try
            {
                await DataProvider.ObrisiSpecijalnuInterventnuJedinicu(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("VratiSvaVozilaJedinice/{idJedinice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiVozilaJed(int idJedinice)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiDodeljivanjaJedinic(idJedinice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiRadnikeJedinice/{idJedinice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiRadnikeJedinice(int idJedinice)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiOperativneRadnikeIzJedincie(idJedinice));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiOpremuJedinice/{idJedinice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiOpremu(int idJedinice)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvuOpremuJedinice(idJedinice));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSvaUcestvovanjaJedinice/{idJedinice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvaUcestvovanja(int idJedinice)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSvaUcestvovanjaJedinice(idJedinice));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
