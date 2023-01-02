using MediatR;

namespace Sandbox.Net7Api
{
    public class UserRequestHandler : IRequestHandler<UserRequest, IResult>
    {
        public async Task<IResult> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            var users = UserGenerator.GenerateUsers();


            return Results.Ok(users.GetRange(0, 20).Select(x => x.Name + request.Tag));

        }
    }
}
