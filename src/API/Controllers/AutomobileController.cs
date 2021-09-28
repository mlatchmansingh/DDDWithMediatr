using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Automobiles.Queries;
using Application.Automobiles.Dtos;
using Application.Automobiles.Commands;

namespace API.Controllers
{
    [ApiController]
    [Route("automobiles")]
    public class AutomobileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutomobileController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<AutomobileSummaryDto>>> GetAllAutomobiles()
        {
            return Ok(await _mediator.Send(new GetAllAutomobiles()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreateAutomobile([FromBody] CreateNewAutomobile createNewautomobile)
        {
            return Ok(await _mediator.Send(createNewautomobile));
        }
    }
}
