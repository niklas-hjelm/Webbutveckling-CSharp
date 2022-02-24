using FirstWebApp.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//TODO: Injecerar AnimalDbContext till v�ran builder. Skickar ocks� med ConnectionString fr�n appsettings.Development.json.
builder.Services.AddDbContext<AnimalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnimalDbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //TODO: Laddar generic exceptionsida om vi publicerar till production (Mer om detta fram�ver) 
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //TODO: L�gger till Strict-Transport-Security header
    app.UseHsts();
}

//TODO: HTTP requests blir redirectade till https
app.UseHttpsRedirection();
//TODO: Laddar static files like CSS, JS, Images, etc.
app.UseStaticFiles();

//TODO: Middleware som best�mmer hur requests ska riktas
app.UseRouting();

//TODO: Skyddar mot obeh�riga anv�ndare (Mer om detta fram�ver)
app.UseAuthorization();

//TODO: L�ter oss styra endpoint-mappning med Razor Pages
app.MapRazorPages();

app.Run();