using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;
using System;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliticarController : ControllerBase
    {

        [HttpGet]
        [Route("GetSviAnaliticari")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Analiticari()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiAnaliticare());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("GetAnaliticar/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAnaliticarPoJmbg(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiAnaliticara(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAnaliticara")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DodajAnaliticara([FromBody] AnaliticarView a)
        {
            try
            {
                await DataProvider.DodajAnalitcar(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniAnaliticara/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniAnaliticara([FromBody] AnaliticarChangeView a, string JMBG)
        {
            try
            {
                await DataProvider.IzmeniAnaliticar(a,JMBG);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiAnaliticara/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiAnaliticara(string JMBG)
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
        [Route("PrikaziEkspertize/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetEkspertizuAnaliticara(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiEkspertizeAnaliticara(JMBG));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("DodajEkspertizu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> DodajEkspertizuAnaliticara([FromBody] EkspertizaChangeView e)
        {
            try
            {
                await DataProvider.DodajEkspertizu(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniEkspertizu/{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniEkspertizuAnaliticara(int Id, [FromBody] EkspertizaChangeView e)
        {
            try
            {
                await DataProvider.IzmeniEkspertizu(e, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiEkspertizu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiEkspertizu(int id)
        {
            try
            {
                await DataProvider.ObrisiEkspertizu(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }


        }

        [HttpGet]
        [Route("GetSveEkspertize")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Ekspertize()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiEkspertize());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PrikaziSoftver/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetSoftver(string JMBG)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSoftvereAnaliticara(JMBG));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSoftver")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> DodajSoftver([FromBody] SoftverAddView e)
        {
            try
            {
                await DataProvider.DodajSoftver(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSoftver/{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> IzmeniSoftver(int Id, [FromBody] SoftverAddView e)
        {
            try
            {
                await DataProvider.IzmeniSoftver(e, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiSoftver/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ObrisiSoftver(int id)
        {
            try
            {
                await DataProvider.ObrisiSoftver(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }


        }

        [HttpGet]
        [Route("GetSviSoftveri")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Softveri()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSoftvere());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
