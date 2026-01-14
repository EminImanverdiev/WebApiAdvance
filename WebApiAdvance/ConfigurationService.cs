using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.DAL.UnitOfWork.Abstract;
using WebApiAdvance.DAL.UnitOfWork.Concrete;
using WebApiAdvance.Entities.Auth;
using WebApiAdvance.Profiles;

namespace WebApiAdvance
{
    public  static class ConfigurationService
    {

        public static IServiceCollection AddConfigurationService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation().
                 AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddSwaggerGen();
            services.AddDbContext<ApiDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddAutoMapper(typeof(BrandProfiles));
            services.AddIdentity<AppUser<Guid>, IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                var tokenOption = configuration.GetSection("TokenOptions").Get<TokenOption>();
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }


    }
}
