using Microsoft.AspNetCore.Identity;
using TheApp.Models;

namespace TheApp.Middleware;

public class BlockedUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HashSet<string> _allowedPaths;

    public BlockedUserMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _allowedPaths =
            new HashSet<string>(configuration.GetSection("AllowedPaths").Get<string[]>() ?? Array.Empty<string>());
    }

    public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
    {
        var path = context.Request.Path.Value?.ToLowerInvariant();

        if (path != null && _allowedPaths.Contains(path))
        {
            await _next(context);
            return;
        }

        if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user == null)
            {
                context.Response.Redirect("/Auth/Login");
                return;
            }

            if (user.IsBlocked)
            {
                context.Response.Redirect("/?blocked=true");
                return;
            }
        }
        else if (path == null || !path.StartsWith("/auth"))
        {
            context.Response.Redirect("/Auth/Login");
            return;
        }

        await _next(context);
    }
}

public static class BlockedUserMiddlewareExtensions
{
    public static IApplicationBuilder UseBlockedUserMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BlockedUserMiddleware>();
    }
}