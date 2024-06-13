using BlazorApp.Components;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.LoginPath = "/Accounts/Login";
        options.AccessDeniedPath = "/Accounts/AccessDenied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddDbContext<DatingAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddQuickGridEntityFrameworkAdapter();;
builder.Services.AddHttpClient();
builder.Services.AddScoped<ProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
    _ = endpoints.MapRazorComponents<App>().AddInteractiveServerRenderMode();
});

app.Run();
