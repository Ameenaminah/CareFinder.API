using System;
using System.IdentityModel.Tokens.Jwt;
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
    // private readonly ILogger<AuthManager> _logger;
    // private ApiUser _user;

    // private const string _loginProvider = "HotelListingApi";
    // private const string _refreshToken = "RefreshToken";

    public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration, ILogger<AuthManager> logger)
    {
      this._mapper = mapper;
      this._userManager = userManager;
      this._configuration = configuration;
      // this._logger = logger;
    }

    public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
    {
      var user = _mapper.Map<ApiUser>(userDto);
      user.UserName = userDto.Email;

      var result = await _userManager.CreateAsync(user, userDto.Password);

      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(user, "User");
      }

      return result.Errors;
    }

    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);
      var isValidCredentials = await _userManager.CheckPasswordAsync(user, loginDto.Password);

      if (user is null || isValidCredentials is false)
      {
        return null;
      }

      var token = await GenerateToken(user);
      
      return new AuthResponseDto()
      {
        UserId = user.Id,
        Token = token,
      };
    }


    private async Task<string> GenerateToken(ApiUser user)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var roles = await _userManager.GetRolesAsync(user);
      var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
      var userClaims = await _userManager.GetClaimsAsync(user);

      var claims = new List<Claim>
              {
                  new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Email, user.Email),
                  new Claim("uid", user.Id)
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
