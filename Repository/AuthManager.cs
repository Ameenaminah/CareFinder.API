﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using CareFinder.API.Interfaces;
using CareFinder.API.Data;
using CareFinder.API.DTOs.User;

namespace CareFinder.API.Repository
{
  public class AuthManager : IAuthManager
  {
    private readonly IMapper _mapper;
    private readonly UserManager<ApiUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthManager> _logger;
    private ApiUser _user;
    private const string _loginProvider = "CareFinderApi";
    private const string _refreshToken = "RefreshToken";

    public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration, ILogger<AuthManager> logger)
    {
      this._mapper = mapper;
      this._userManager = userManager;
      this._configuration = configuration;
      this._logger = logger;
    }

    public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
    {
      _user = _mapper.Map<ApiUser>(userDto);
      _user.UserName = userDto.Email;

      var result = await _userManager.CreateAsync(_user, userDto.Password);

      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(_user, "User");
      }

      return result.Errors;
    }

    public async Task<IEnumerable<IdentityError>> RegisterAdmin(ApiUserDto userDto)
    {
      _user = _mapper.Map<ApiUser>(userDto);
      _user.UserName = userDto.Email;

      var result = await _userManager.CreateAsync(_user, userDto.Password);

      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(_user, "User");
        await _userManager.AddToRoleAsync(_user, "Administrator");
      }

      return result.Errors;
    }

    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {
      _logger.LogInformation($"Looking for user with email: {loginDto.Email}");

      _user = await _userManager.FindByEmailAsync(loginDto.Email);
      var isValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

      if (_user is null || isValidCredentials is false)
      {
        _logger.LogWarning($"User with email {loginDto.Email} was not found");

        return null;
      }

      var token = await GenerateToken();
      _logger.LogInformation($"generated a token : {token} for user with email : {loginDto.Email}");
      return new AuthResponseDto()
      {
        UserId = _user.Id,
        Token = token,
        RefreshToken = await CreateRefreshToken()
      };
    }

    public async Task<string> CreateRefreshToken()
    {
      await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
      var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
      var result = _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);

      return newRefreshToken;
    }

    public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
    {
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
      var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
      _user = await _userManager.FindByEmailAsync(username);

      if (_user == null)
      {
        return null;
      }

      var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

      if (isValidRefreshToken)
      {
        var token = await GenerateToken();

        return new AuthResponseDto
        {
          UserId = _user.Id,
          Token = token,
          RefreshToken = await CreateRefreshToken()
        };
      }

      await _userManager.UpdateSecurityStampAsync(_user);
      return null;
    }

    private async Task<string> GenerateToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var roles = await _userManager.GetRolesAsync(_user);
      var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
      var userClaims = await _userManager.GetClaimsAsync(_user);

      var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim(JwtRegisteredClaimNames.Name, _user.FirstName),
                new Claim("uid", _user.Id)
            }
      .Union(userClaims).Union(roleClaims);

      var token = new JwtSecurityToken(
          issuer: _configuration["JwtSettings:Issuer"],
          audience: _configuration["JwtSettings:Audience"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
          signingCredentials: credentials
          );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
