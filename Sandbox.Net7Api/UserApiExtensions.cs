using MediatR;

namespace Sandbox.Net7Api
{
    public static class UserApiExtensions
    {
        public static WebApplication MediateGet<TRequest>(
            this WebApplication app, 
            string template) where TRequest : IHttpRequest
        {
            app.MapGet(template, async (IMediator mediator,
                [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }
    }
}
