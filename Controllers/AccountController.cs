using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CareFinder.API.Interfaces;
using CareFinder.API.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareFinder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
  private readonly IAuthManager _authManager;
  private readonly ILogger<AccountController> _logger;

  public AccountController(IAuthManager authManager)
  {
    this._authManager = authManager;
  }

  // POST api/account/register
  [HttpPost]
  [Route("register")]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> Register([FromBody] ApiUserDto apiUserDto)
  {
    try
    {
      var errors = await _authManager.Register(apiUserDto);

      if (errors.Any())
      {
        foreach (var error in errors)
        {
          ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(errors);
      }

      return Ok();
    }
    catch (Exception ex)
    {
      _logger.LogError($"An error occurred while trying to register user with email : {apiUserDto.Email}", ex.Message);
      return Problem();
    }
  }

  // POST api/auth/login
  [HttpPost]
  [Route("login")]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
  {
    var authResponse = await _authManager.Login(loginDto);

    if (authResponse == null)
    {
      return Unauthorized();
    }
    return Ok(authResponse);
  }

  [HttpPost]
  [Route("refresh-token")]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> RefreshToken([FromBody] AuthResponseDto request)
  {
    var authResponse = await _authManager.VerifyRefreshToken(request);

    if (authResponse is null)
    {
      return Unauthorized();
    }

    return Ok(authResponse);
  }
}
