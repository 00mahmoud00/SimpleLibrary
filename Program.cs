using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleLibrary.Services.Authors;
using SimpleLibrary.Services.Books;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // some code
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Response.Redirect("/Home/NotFound");
    }
});

app.Use(async (context, next) =>
{
    var bannedIps = new List<string>() { "" };
    var ip = context.Connection.RemoteIpAddress!.MapToIPv4().ToString();
    if (bannedIps.Contains(ip) && !context.Request.Path.Value!.StartsWith("/Banned/Index"))
    {
        context.Response.Redirect("/Banned/Index");
    }
    await next();
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();