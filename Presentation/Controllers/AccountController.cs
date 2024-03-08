using Application.AccountHandler;
using Application.AccountHandler.Commands;
using AutoMapper;
using Domain.Entity.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class AccountController(IMapper mapper, IMediator mediator) : Controller
{
    private const string ViewUrl = "~/Views/Auth/index.cshtml";

    public IActionResult Index()
    {
        return View(ViewUrl);
    }

    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        var command = mapper.Map<RegisterViewModel, Register.Command>(registerViewModel);
        var result = await mediator.Send(command);
        return result.IsFailure ? BadRequest(result.Errors) : Ok(result.Value);
    }
}
