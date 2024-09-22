﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

[ApiController]
[Route("/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UserManager<Usuario> _userManager;

    public UsuariosController(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetUsuariosAtivos()
    {
        var usuariosAtivos = _userManager.Users
            .Where(u => u.LockoutEnd == null || u.LockoutEnd <= DateTimeOffset.Now)
            .ToList();

        return Ok(usuariosAtivos);
    }
}
