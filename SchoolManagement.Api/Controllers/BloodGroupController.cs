﻿using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BloodGroup;
using SchoolManagement.Application.Features.BloodGroups.Requests.Commands;
using SchoolManagement.Application.Features.BloodGroups.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BloodGroup)]
[ApiController]
[Authorize]
public class BloodGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bloodGroups")]
    public async Task<ActionResult<List<BloodGroupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BloodGroups = await _mediator.Send(new GetBloodGroupListRequest { QueryParams = queryParams });
        return Ok(BloodGroups);
    }

    [HttpGet]
    [Route("get-bloodGroupDetail/{id}")]
    public async Task<ActionResult<BloodGroupDto>> Get(int id)
    {
        var BloodGroups = await _mediator.Send(new GetBloodGroupDetailRequest { BloodGroupId = id });
        return Ok(BloodGroups);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bloodGroup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBloodGroupDto BloodGroup)
    {
        var command = new CreateBloodGroupCommand { BloodGroupDto = BloodGroup };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bloodGroup/{id}")]
    public async Task<ActionResult> Put([FromBody] BloodGroupDto BloodGroup)
    {
        var command = new UpdateBloodGroupCommand { BloodGroupDto = BloodGroup };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bloodGroup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBloodGroupCommand { BloodGroupId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedBloodGroups")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBloodGroup()
    {
        var bloodgroup = await _mediator.Send(new GetSelectedBloodGroupRequest { });
        return Ok(bloodgroup);
    }
}

