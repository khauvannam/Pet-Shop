using Application.Accounts.Commands;
using AutoMapper;
using Domain.Entity.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers;

public class AccountController(
    IMapper mapper,
    ISender mediator,
    IValidator<RegisterViewModel> validator
) : Controller
{
    private const string ViewUrl = "~/Views/Auth/index.cshtml";

    public IActionResult Index()
    {
        return View(ViewUrl);
    }

    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        var validationResult = await validator.ValidateAsync(registerViewModel);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);
            return View(ViewUrl, registerViewModel);
        }

        var command = mapper.Map<RegisterViewModel, Register.Command>(registerViewModel);
        var result = await mediator.Send(command);
        if (result.IsFailure)
        {
            ViewBag.ErrorMessage = result.Errors;
        }

        return RedirectToAction("Index", "Home");
    }
}
