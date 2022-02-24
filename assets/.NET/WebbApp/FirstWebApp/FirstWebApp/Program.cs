using FirstWebApp.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//TODO: Injecerar AnimalDbContext till våran builder. Skickar också med ConnectionString från appsettings.Development.json.
builder.Services.AddDbContext<AnimalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnimalDbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //TODO: Laddar generic exceptionsida om vi publicerar till production (Mer om detta framöver) 
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //TODO: Lägger till Strict-Transport-Security header
    app.UseHsts();
}

//TODO: HTTP requests blir redirectade till https
app.UseHttpsRedirection();
//TODO: Laddar static files like CSS, JS, Images, etc.
app.UseStaticFiles();

//TODO: Middleware som bestämmer hur requests ska riktas
app.UseRouting();

//TODO: Skyddar mot obehöriga användare (Mer om detta framöver)
app.UseAuthorization();

//TODO: Låter oss styra endpoint-mappning med Razor Pages
app.MapRazorPages();

app.Run();