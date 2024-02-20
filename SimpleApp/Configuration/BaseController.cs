using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Configuration
{
    public class BaseController : Controller
    {
        private IMediator mediatorInstance;
        protected IMediator mediator => mediatorInstance ?? (mediatorInstance = this.HttpContext.RequestServices.GetService<IMediator>());
    }
}
