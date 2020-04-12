using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VemDeZap.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using VemDeZap.Domain.Commands.Usuario.AdicionarUsuario;
using VemDeZap.Api.Security;
using System;
using Microsoft.AspNetCore.Authorization;
using VemDeZap.Infra.Repositories;

namespace VemDeZap.Api
{
    public static class Setup
    {
        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(AdicionarUsuarioRequest).GetTypeInfo().Assembly);
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "VemDeZap", Version = "v1" });
            });
        }
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            //configurar token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())
            };

            services.AddSingleton(tokenConfigurations);
            services.AddAuthentication(authOption =>
            {
                authOption.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOption.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                //paramsValidation.ValidateAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                //valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                //varefica se o token recebido ainda e valido
                paramsValidation.RequireExpirationTime = true;

                //tepo de tolerancia para a expiração de um token(utilizado 
                //caso haja problemas de sinfronismo de horario entre deferentes
                //computatoes envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;

            });

            //services.AddAuthentication(auth =>
            //{
            //    auth.AddScheme("Beared", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            //});
        }
        // public static void ConfigureMVC(this IServiceCollection services)
        // {
        //     services.AddMvc(options =>{

        //     }).s
        // }
    }
}
