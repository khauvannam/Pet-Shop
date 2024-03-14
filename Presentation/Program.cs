using Application;
using Presentation.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (context, loggerConfig) => { loggerConfig.ReadFrom.Configuration(context.Configuration); }
);
var services = builder.Services;
services.AddControllersWithViews();
services.AddService();
services.AddIdentityConfig();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseAuthentication();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();