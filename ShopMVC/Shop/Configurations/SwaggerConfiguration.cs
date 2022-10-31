using Microsoft.OpenApi.Models;

namespace Shop.Configurations;

public static class SwaggerConfiguration
{
    public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API"
                });

                var dir = new DirectoryInfo(AppContext.BaseDirectory);
    
                var fileInfos = dir.EnumerateFiles("*.xml").ToList();

                foreach (var fileInfo in fileInfos)
                {
                    options.IncludeXmlComments(fileInfo.FullName);
                }
            });
        }

        public static void Use(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        }
}