using IVCRM.API.Filters;
using Microsoft.OpenApi.Models;

namespace IVCRM.API
{
    public static class ServiceCollectionRegistry
    {
        private const string AuthorizationUrl = "Authorization:AuthorizationUrl";
        private const string TokenUrl = "Authorization:TokenUrl";
        public static void AddSwaggerWithSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(configuration[AuthorizationUrl]),
                            TokenUrl = new Uri(configuration[TokenUrl]),
                            Scopes = new Dictionary<string, string>
                            {
                                {"productAPI", "ProductAPI - full access"}
                            }
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }
    }
}
