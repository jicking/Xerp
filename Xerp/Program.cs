using AutoWrapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Xerp.Core.Services;
using Xerp.Data;

namespace Xerp;

public class Program {
	public static void Main(string[] args) {
		var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
		logger.Debug("Xerp Service Start =================");

		try {
			var builder = WebApplication.CreateBuilder(args);

			// NLog: Setup NLog for Dependency injection
			builder.Logging.ClearProviders();
			builder.Host.UseNLog();

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			// Swagger config
			builder.Services.AddSwaggerGen(option => {
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "Xerp API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement {
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference {
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			});

			// CORS
			builder.Services.AddCors(options => {
				options.AddDefaultPolicy(policy => {
					policy
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			// Auth
			builder.Services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => {
				options.Authority = "https://jickingdev.us.auth0.com/";
				options.Audience = "xerp-service";
			});

			// Add custom options
			//builder.Services.Configure<AppOptions>(builder.Configuration.GetSection(AppOptions.GoogleRecaptcha));

			// Add custom services
			builder.Services.AddScoped<IAuthTokenService, Auth0TokenService>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();

			// EF
			builder.Services.AddDbContext<XerpDbContext>(o => o.UseInMemoryDatabase("XerpDbContext"));
			//var connectionString = builder.Configuration.GetConnectionString("XerpDbContext");
			//builder.Services.AddDbContext<XerpDbContext>(options =>
			//	options.UseSqlServer(connectionString));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Error");
			}

			app.UseHsts();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			if (!app.Environment.IsProduction()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapRazorPages();
			app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsApiOnly = false });
			app.MapControllers();

			app.Run();
		}
		catch (Exception exception) {
			// NLog: catch setup errors
			logger.Error(exception, "Xerp Service Error =================");
			throw;
		}
		finally {
			// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
			NLog.LogManager.Shutdown();
			logger.Debug("Xerp Service Stop =================");
		}
	}
}