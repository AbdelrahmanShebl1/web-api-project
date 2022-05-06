using Microsoft.EntityFrameworkCore;
using web_api_project.Models.context;
using web_api_project.Models.Services;
using System.Text;
using Microsoft.EntityFrameworkCore.Proxies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//builder.Services.AddDbContext<ShopContext>(options =>
//{
//    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ShopDB"));
//});
builder.Services.AddDbContext<ShopContext>(o => o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ShopDB")));

// Custom Services
builder.Services.AddScoped<IPhoneRepo, PhoneRepo>();
builder.Services.AddScoped<ShopContext, ShopContext>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
