using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Configurations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(options => options.Filters.Add<Shop.Filters.ExceptionFilter>());

DependencyInjectionConfiguration.Configure(builder.Services, builder.Configuration);
SwaggerConfiguration.Configure(builder.Services);

var app = builder.Build();

SwaggerConfiguration.Use(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
