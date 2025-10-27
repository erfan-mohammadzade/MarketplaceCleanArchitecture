using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Entities;
using Marketplace.Infrustructure.Presentation;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Presentation.Controller;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
   private readonly IUserService _userService;

   public UserController(IUserService userService)
   {
      _userService = userService;
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetUser(int id)
   {
      var user = await _userService.GetUserWithItemsAsync(id);
      if(user == null) return NotFound();
      return Ok(user);
   }

   [HttpPost]
   public async Task<IActionResult> CreateUser([FromBody] User user)
   {
      var createdUser = await _userService.CreateUserAsync(user);
      return CreatedAtAction(nameof(GetUser), new {createdUser}, user);
   }

   [HttpPost("{id}/item")]
   public async Task<IActionResult> CreateItem(int id, [FromBody] Item item)
   {
      await _userService.AddItemToUserAsync(id, item);
      return NoContent();
   }
}