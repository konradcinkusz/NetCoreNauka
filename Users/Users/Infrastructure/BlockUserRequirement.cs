using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure
{
    public class BlockUserRequirement : IAuthorizationRequirement
    {
        public BlockUserRequirement(params string[] users)
        {
            BlockedUsers = users;
        }
        public string[] BlockedUsers { get; set; }
    }
    public class BlockUsersHandler : AuthorizationHandler<BlockUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BlockUserRequirement requirement)
        {
            if (context.User.Identity != null && context.User.Identity.Name != null && !requirement.BlockedUsers.Any(user => user.Equals(context.User.Identity.Name, System.StringComparison.OrdinalIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
