using AkBrandMobile.BAL;
using AkBrandMobile.Common;
using AkBrandMobile.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<MobileTransaction>(); // MobileTransaction service
builder.Services.AddScoped<MobileDbConnection>(); // MobileDbConnection service
builder.Services.AddScoped<ConversionsClass>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Configure CORS Policy (UPDATED)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://brand-mobile-new.vercel.app", "https://brand-mobile-new-prathamesh-pailwans-projects.vercel.app/") // ✅ Allow both local and Vercel app
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // ✅ Allow authentication cookies/tokens
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
