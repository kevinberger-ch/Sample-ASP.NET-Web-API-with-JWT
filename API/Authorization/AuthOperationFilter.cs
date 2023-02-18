using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Authorization;


public class AuthOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {

        var methodAuthAttribute = context.MethodInfo?
            .GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>()
            .Distinct();

        var methodAllowAnonymAttribute = context.MethodInfo?
            .GetCustomAttributes(true)
            .OfType<AllowAnonymousAttribute>()
            .Distinct();

        var classAuthAttribute = context.MethodInfo?.DeclaringType?
            .GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>()
            .Distinct();

        // check if method is secured 
        if (methodAuthAttribute != null && methodAuthAttribute.Any() || (classAuthAttribute != null && classAuthAttribute.Any() && methodAllowAnonymAttribute != null && !methodAllowAnonymAttribute.Any()))
        {
            // if method is secured
            // add possible 401 response
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });

            var jwtBearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            };

            // add security requirement (shown in swagger) 
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ jwtBearerScheme ] = new string [] { }
                }
            };
        }
    }
}