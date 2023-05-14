using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using POS.API.Filters;
using POS.Business;

namespace POS.API
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
      => _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        var frontURL = _configuration.GetValue<string>("CientURL");
        options.AddPolicy("AllowWebApp", builder => builder.WithOrigins(frontURL)
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod());
      });
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
      services.AddControllers(options =>
      {
        options.Filters.Add(typeof(POSExceptionsLogger));
        options.Filters.Add(typeof(BadRequestParse));
      });
      services.AddBusinessInjection();
      services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("alpha", new OpenApiInfo { Title = "POS", Version = "alpha" });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // Configure the HTTP request pipeline.
      if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
          app.UseSwagger();
          app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/alpha/swagger.json", "POS"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("AllowWebApp");

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
          endpoints.MapControllers());
    }
  }
}
