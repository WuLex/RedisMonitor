using Microsoft.AspNetCore.Mvc.Infrastructure;
using RedisMonitor.Core.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
//注入一个服务
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
CoreExtension.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
