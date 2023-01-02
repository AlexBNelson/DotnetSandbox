using MediatR;

namespace Sandbox.Net7Api
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
