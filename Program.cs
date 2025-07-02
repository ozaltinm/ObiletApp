using ObiletApp.Helpers;
using ObiletApp.Helpers.Interfaces;
using ObiletApp.Options;
using ObiletApp.Services;
using ObiletApp.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ObiletApiOptions>(
    builder.Configuration.GetSection("ObiletApi"));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IObiletApiService, ObiletApiService>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IObiletApiService, ObiletApiService>();
builder.Services.AddScoped<ISessionManager, SessionManager>();
builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
