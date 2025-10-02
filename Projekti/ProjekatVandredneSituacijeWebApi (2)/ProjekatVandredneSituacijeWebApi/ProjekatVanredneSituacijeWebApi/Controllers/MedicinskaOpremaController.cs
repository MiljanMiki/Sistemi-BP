using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinskaOpremaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvuMedicinskuOpremu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSvuMedicinskuOpremu()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiMedicinskuZastitu());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiMedicinskuZastitu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiMedicinskuOpremu(string Serijski_Broj)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiMedicinskuOpremu(Serijski_Broj));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
       
        }

        [HttpPost]
        [Route("DodajMedicinskuOpremu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> DodajMedicinskuOpremu([FromBody] MedicinskaOpremaAddView m)
        {
            try
            {
                await DataProvider.DodajMedicinskuOpremu(m);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniMedicinskuOpremu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniMedicinskuOpremu(string Serijski_Broj, [FromBody] MedicinskaOpremaChangeView m)
        {
            try
            {
                await DataProvider.IzmeniMedicinskuOpremu(Serijski_Broj, m);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiMedicinskuOpremu/{Serijski_Broj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiMedicinskuOpremu(string Serijski_Broj)
        {
            try
            {
                await DataProvider.ObrisiMedicinskuOpremu(Serijski_Broj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
