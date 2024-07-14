
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WisApi.Data;
using WisApi.Models;
using WisApi.Repositories.Interfaces;
using WisApi.Repositories.Services;

namespace WisApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Auth Db Context Microsoft SQL Server
            //builder.Services.AddDbContext<AuthDbContext>(options =>
            //{
            //    options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("DefaultAuthConnection") ?? throw new InvalidOperationException("Could not find connection string: 'DefaultAuthConnection'."));

            //    options.EnableSensitiveDataLogging();
            //});


            ////Application Db Context Microsoft SQL Server
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Could not find connection string: 'DefaultConnection'.")));

            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseMySql(Secrets.AuthCString, ServerVersion.AutoDetect(Secrets.AuthCString)));


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Secrets.GeneralCString, ServerVersion.AutoDetect(Secrets.GeneralCString)));


            //Services DI
            builder.Services.AddScoped<ITokenRepository, TokenService>();
            builder.Services.AddScoped<IAuthRepository, AuthService>();
            builder.Services.AddScoped<ITopicRepository, TopicService>();
            builder.Services.AddScoped<IPostRepository, PostService>();
            builder.Services.AddScoped<ICommentRepository, CommentService>();
            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<IReportRepository, ReportService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            //Setting up Swagger to use Auth
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WIS API", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });


            //Bad Password only for development
            // Identity & Auth config
            builder.Services.AddIdentity<ExtendedIdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
            });

            builder.Services.AddAuthorization();


            //Setting up CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "WisCors",
                    policy =>
                    {
                        policy.WithOrigins(
                            "http://localhost:5173",
                            "http://localhost:5174",
                            "http://whatisspace.online")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Images")),
            //    RequestPath = "/images"
            //});

            app.UseCors("WisCors");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
