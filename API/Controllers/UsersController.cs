using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// [ApiController]
// [Route("api/[Controller]")] // /api/Users

public class UsersController  (DataContext context): BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
    {
        var users = await context.Users.ToListAsync();

        //we can return the users but when we're using the action result we ge the ability to return HTTP response such as OK()
        //return Ok(users);
        //we will return simply users because it will return also an Ok hhtpresponse
        return users;
    }
    [Authorize]
    [HttpGet("{id:int}")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUser (int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;
    }
}
