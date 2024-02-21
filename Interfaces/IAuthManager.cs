using System;
using CareFinder.API.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace CareFinder.API.Interfaces
{
  public interface IAuthManager
  {
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
    // Task<IEnumerable<IdentityError>> RegisterAdmin(ApiUserDto userDto);
     Task<string> CreateRefreshToken();
     Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

  }
}