using FinanceTracker.Service;
using FinanceTracker.Service.DTOs.UserDTOs;
using FinanceTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(
    IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUser([FromQuery] PageService page)
    {
        var result = await userService.RetrieveAllAsync(page);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserForCreationDto dto)
    {
        var user = await userService.AddAsync(dto);

        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] long id)
    {
        var result = await userService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] long id, [FromBody] UserForUpdateDto dto)
    {
        var result = await userService.ModifyAsync(id, dto);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(long id)
    {
        var user = await userService.RetrieveByIdAsync(id);

        return Ok(user);
    }
}
