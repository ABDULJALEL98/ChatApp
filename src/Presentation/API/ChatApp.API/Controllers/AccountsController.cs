﻿using ChatApp.Application.Features.Accounts.Command.Login;
using ChatApp.Application.Features.Accounts.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers;


public class AccountsController : BaseController
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    [HttpPost(template:"login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var command = new LoginCommand(loginDto);
                var response = await _mediator.Send(command);
                if (response.IsSuccess)
                {
                    return Ok(response.Data);
                }
                if (response.IsSuccess == false && response.Message == "unAuthorized")
                {
                    return Unauthorized();
                }
                if (response.IsSuccess == false && response.Message == "notFound")
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }
        catch (Exception ex)  
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPost(template:"register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var command = new RegisterCommand(registerDto);
                var response = await _mediator.Send(command);
                if (response.IsSuccess)
                {
                    return Ok(response.Data); 
                }
                if (response.IsSuccess == false)
                {
                    return BadRequest(response.Errors);
                }
                return BadRequest(response.Message);
            }
            return BadRequest();
        }
        catch (Exception)
        {
            throw;
        }
    }
}