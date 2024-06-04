using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamenGo_API_Application.Interfaces;
using RamenGo_API_Application.Models;
using System.ComponentModel.DataAnnotations;

namespace RamenGo_API_Service.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class RamenController : ControllerBase
    {
        private readonly IRamenAppService _ramenAppService;

        public RamenController(IRamenAppService ramenAppService)
        {
            _ramenAppService = ramenAppService;
        }

        /// <summary>
        /// List all avaliable broths
        /// </summary>
        /// <param name="apiKey"></param>
        [HttpGet]
        [Route("broths")]
        [ProducesResponseType(200, Type = typeof(List<BrothModel>))]
        [ProducesResponseType(403, Type = typeof(ErrorModel))]
        public IActionResult GetBroths([FromHeader(Name = "x-api-key"), Required] string apiKey)
        {
            try
            {
                var broths = _ramenAppService.GetBrouts();
                
                return Ok(broths);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel()
                {
                    Error = ex.Message,
                });
            }

        }

        /// <summary>
        /// List all avaliable proteins
        /// </summary>
        /// <param name="apiKey"></param>
        [HttpGet]
        [Route("proteins")]
        [ProducesResponseType(200, Type = typeof(List<ProteinModel>))]
        [ProducesResponseType(403, Type = typeof(ErrorModel))]
        public IActionResult GetProteins([FromHeader(Name = "x-api-key"), Required] string apiKey)
        {
            try
            {
                var proteins = _ramenAppService.GetProteins();
                
                return Ok(proteins);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel()
                {
                    Error = ex.Message,
                });
            }
        }

        /// <summary>
        /// Place an order
        /// </summary>
        /// <param name="apiKey"></param>
        [HttpPost]
        [Route("order")]
        [ProducesResponseType(201, Type = typeof(OrderResponseModel))]
        [ProducesResponseType(400, Type = typeof(ErrorModel))]
        [ProducesResponseType(403, Type = typeof(ErrorModel))]
        [ProducesResponseType(500, Type = typeof(ErrorModel))]
        public async Task<IActionResult> PostOrder([FromHeader(Name = "x-api-key"), Required] string apiKey, [FromBody]OrderRequestModel model)
        {
            try
            {
                var order = await _ramenAppService.AddOrder(model);

                return CreatedAtAction(nameof(PostOrder), order);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel
                {
                    Error = "Both brothId and proteinId are required"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel()
                {
                    Error = ex.Message,
                });
            }
        }
    }
}
