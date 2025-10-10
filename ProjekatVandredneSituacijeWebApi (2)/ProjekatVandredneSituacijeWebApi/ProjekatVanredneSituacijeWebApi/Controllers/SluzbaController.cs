using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Threading.Tasks.Sources;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

namespace ProjekatVanredneSituacijeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SluzbaController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSluzbe")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSluzbe()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSluzbe());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiPredstavnikaSluzbe/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> VratiPredstavnikaSluzbe(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiPredstacnikaJedinice(Id));
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiSluzbu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiSluzbu(int Id)
        {
            try
            {
                return new JsonResult(await DataProvider.VratiSluzbu(Id));
  
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSluzbu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DodajSluzbu([FromBody] SluzbaAddView s)
        {
            try
            {
                await DataProvider.DodajSluzbu(s);
                return Ok(); ;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut]
        [Route("IzmeniSluzbu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> IzmeniSluzbu([FromBody] SluzbaAddView s,int Id)
        {
            try
            {
                await DataProvider.IzmeniSluzbu(s, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }   
        }

        [HttpDelete]
        [Route("ObrisiSluzbu/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiSluzbu(int Id)
        {
            try
            {
                await DataProvider.ObrisiSluzbu(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPredstavnika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajPredstavnika([FromBody] PredstavnikView p)
        {
            try
            {
                await DataProvider.DodajPredstavnika(p);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniPredstavnika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
     
        public async Task<IActionResult> IzmeniPredstavnika([FromBody] PredstavnikChangeView p,string JMBG)
        {
            try
            {
                await DataProvider.IzmeniPredstavnika(p, JMBG);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiPredstavnika/{JMBG}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObrisiPredstavnika(string JMBG)
        {
            try
            {
                await DataProvider.ObrisiPredstavnika(JMBG);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

   

        [HttpGet]
        [Route("VratiPredstavnike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> VratiPredstavnike()
        {
            try
            {
                return new JsonResult(await DataProvider.VratiPredstavnike());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
