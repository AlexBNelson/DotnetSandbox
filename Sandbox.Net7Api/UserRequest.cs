using MediatR;

namespace Sandbox.Net7Api
{
    public class UserRequest : IHttpRequest
    {
        public string Tag { get; set; }
    }
}
