using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var user = await _userService.GetAllUsersAsync();
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        if (id <= 0) return BadRequest("The user id must be greater than zero");

        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);           
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); 

        try
        {
            await _userService.RegisterUserAsync(user);
            return Ok("User registered successfully");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User login)
    {
        if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.PasswordHash))
        {
            return BadRequest("Username or password cannot be null or empty.");
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        bool isValidUser = await _userService.ValidateUserAsync(login.Username, login.PasswordHash);
        
        if (!isValidUser) return Unauthorized("Invalid username or password");

        return Ok("Login successful");
    }

    
}
