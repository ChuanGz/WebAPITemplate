using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Integration.API.Models;
using Integration.API.Swagger;
using Integration.BLL.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Integration.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/agreements")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAgreementsService _agreementsService;

        /// <summary>
        /// Agreements db api
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="agreementsService"></param>
        public AgreementsController(IMapper mapper, IAgreementsService agreementsService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _agreementsService = agreementsService ?? throw new ArgumentNullException(nameof(agreementsService));
        }

        /// <summary>
        /// Create a new agreement
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns>Returns created agreement</returns>           
        [HttpPost("")]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Agreement), Description = "Returns created agreement")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> CreateAgreementAsync([FromBody] Agreement agreement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _agreementsService.CreateAgreementAsync(_mapper.Map<BLL.Models.Agreement>(agreement));
            return Created($"{result.Id}", _mapper.Map<Agreement>(result));
        }

        /// <summary>
        /// Get agreement by id
        /// </summary>
        /// <param name="id">Agreement Id</param>
        /// <returns>Returns finded agreement</returns>
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Agreement), Description = "Returns finded agreement")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid agreement id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetAgreementAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _agreementsService.GetAgreementAsync(id);
            if (result == null)
            {
                return NotFound(new { id });
            }

            return Ok(_mapper.Map<Agreement>(result));
        }

        /// <summary>
        /// Update existing agreement
        /// </summary>
        /// <param name="id">Agreement id</param>
        /// <param name="agreement">Agreement parameters</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid agreement object")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> UpdateAgreementAsync([FromRoute] Guid id, [FromBody] Agreement agreement)
        {
            if (id == Guid.Empty || !ModelState.IsValid)
            {
                return BadRequest();
            }

            agreement.Id = id;
            await _agreementsService.UpdateAgreementAsync(_mapper.Map<BLL.Models.Agreement>(agreement));
            return Ok();
        }

        /// <summary>
        /// Delete agreement
        /// </summary>
        /// <param name="id">Agreement id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid agreement id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> DeleteAgreementAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _agreementsService.DeleteAgreementAsync(id);
            return Ok();
        }

        /// <summary>
        /// Get agreements list
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Agreement>), Description = "Returns finded agreements array")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetAgreementsListAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            if (pageNumber == 0 || pageSize == 0)
            {
                return BadRequest();
            }

            var result = await _agreementsService.GetAgreementsListAsync(pageNumber, pageSize);
            return Ok(_mapper.Map<IEnumerable<Agreement>>(result));
        }
    }
}
