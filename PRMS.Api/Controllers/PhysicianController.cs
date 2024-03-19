﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRMS.Api.Dtos;
using PRMS.Core.Abstractions;
using PRMS.Core.Dtos;

namespace PRMS.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/physician")]
public class PhysicianController : ControllerBase
{
    private readonly IPhysicianService _physicianService;

    public PhysicianController(IPhysicianService physicianService)
    {
        _physicianService = physicianService;
    }

    [HttpGet("{physicianId}")]
    public async Task<IActionResult> GetPhysicianDetails([FromRoute] string physicianId)
    {
        var result = await _physicianService.GetDetails(physicianId);
        if(result.IsFailure)
            return BadRequest(ResponseDto<object>.Failure(result.Errors));

        return Ok(ResponseDto<object>.Success(result.Data));
    }

    [HttpGet("{physicianId}/reviews")]
    public async Task<IActionResult> GetReviews([FromRoute] string physicianId, PaginationFilter? paginationFilter)
    {
        paginationFilter ??= new PaginationFilter();
        var result = await _physicianService.GetReviews(physicianId, paginationFilter);
        if(result.IsFailure)
            return BadRequest(ResponseDto<object>.Failure(result.Errors));

        return Ok(ResponseDto<object>.Success(result.Data));
    }
}