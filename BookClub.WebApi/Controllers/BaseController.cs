using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BookClub.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[acion]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int UserId => !User.Identity.IsAuthenticated 
            ? 0 : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
