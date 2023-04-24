using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace lab.Repository;

public class AuthManager : IAuthManager
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private IdentityUser _user;

    private const string _loginProvider = "restaurantsApi";
    private const string _refreshToken = "RefreshToken";

    public AuthManager(IMapper mapper, UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        this._mapper = mapper;
        this._userManager = userManager;
        this._configuration = configuration;
    }

    public async Task<string> CreateRefreshToken()
    {
        await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
        var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
        var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);
        return newRefreshToken;
    }

    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {
        _user = await _userManager.FindByNameAsync(loginDto.UserName);
        bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

        if (_user == null || isValidUser == false)
        {
            return null;
        }

        var token = await GenerateToken();

        return new AuthResponseDto
        {
            UserName = _user.UserName,
            Token = token,
            UserId = _user.Id,
            RefreshToken = await CreateRefreshToken()
        };
    }

    public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
    {
        //Validateting for some errors that userManager does not validate
        // var errors = new List<IdentityError>();
        // if (!Regex.IsMatch(userDto.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
        // {
        //     var error = new IdentityError
        //     {
        //         Code = "Email",
        //         Description = "Invalid Email"
        //     };
        //     errors.Add(error);
        // }
        // if (!Regex.IsMatch(userDto.PhoneNumber, @"^\+?\d{10,12}$"))
        // {
        //     var error = new IdentityError
        //     {
        //         Code = "PhoneNumber",
        //         Description = "Invalid phone number"
        //     };
        //     errors.Add(error);
        // }
        // var user = await _userManager.FindByEmailAsync(userDto.Email);
        // if (user != null)
        // {
        //     var error = new IdentityError
        //     {
        //         Code = "Email",
        //         Description = "This email is already taken"
        //     };
        //     errors.Add(error);
        // }

        // if (errors.Count > 0)
        // {
        //     return errors;
        // }

        _user = _mapper.Map<IdentityUser>(userDto);
        _user.UserName = userDto.UserName;

        var result = await _userManager.CreateAsync(_user, userDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(_user, "User");
        }

        return result.Errors;
    }

    public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
        var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Sub)?.Value;
        _user = await _userManager.FindByNameAsync(username);

        if (_user == null || _user.Id != request.UserId)
        {
            return null;
        }

        var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

        if (isValidRefreshToken)
        {
            var token = await GenerateToken();
            return new AuthResponseDto
            {
                UserName = _user.UserName,
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        await _userManager.UpdateSecurityStampAsync(_user);
        return null;
    }

    private async Task<string> GenerateToken()
    {
        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

        var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(_user);
        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(_user);

        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
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
