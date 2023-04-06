using System.Security.Claims;
using API.Core;
using API.Domain;
using API.DTO.User;
using API.helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _token;
    public AccountController(UserManager<AppUser> userManager, TokenService token)
    {
        _token = token;
        _userManager = userManager;

    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccountResult<UserDTO>>> Login(LoginDto userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin.Email);

        if (user is null)
        {

            return Unauthorized(AccountResult<UserDTO>.Failure("Email or password is wrong"));
        }

        var result = await _userManager.CheckPasswordAsync(user, userLogin.Password);

        if (!result)
            return Unauthorized(AccountResult<UserDTO>.Failure("Email or password is wrong"));

        var userResult = new UserDTO
        {

            Username = user.UserName,
            Token = _token.GenerateToken(user),
            Image = null,
            DisplayName = user.DisplayName
        };

        return AccountResult<UserDTO>.Success(CreateUserResult(user));

    }
    [AllowAnonymous]
    [HttpPost("new")]
    public async Task<ActionResult<AccountResult<UserDTO>>> RegisterUser(RegisterDto registerUser)
    {
        if (await _userManager.Users.AnyAsync(user => user.UserName == registerUser.Username))
        {
            return BadRequest(AccountResult<UserDTO>.Failure("Username is already in use"));

        }

        if (await _userManager.Users.AnyAsync(user => user.Email.ToLower() == registerUser.Email.ToLower()))
        {
            return BadRequest(AccountResult<UserDTO>.Failure("Email is already in use"));
        }

        var user = new AppUser
        {
            Email = registerUser.Email,
            UserName = registerUser.Username,
            DisplayName = registerUser.DisplayName,

        };

        var result = await _userManager.CreateAsync(user, registerUser.Password);

        if (result.Succeeded)
        {

            return AccountResult<UserDTO>.Success(CreateUserResult(user));
        }

        return BadRequest(result);

    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDTO>> Me()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
        return CreateUserResult(user);
    }

    private UserDTO CreateUserResult(AppUser user)
    {

        return new UserDTO
        {
            Username = user.UserName,
            Token = _token.GenerateToken(user),
            DisplayName = user.DisplayName,
            Image = null

        };
    }
}

