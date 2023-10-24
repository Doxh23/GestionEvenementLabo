using GestionEvenementLabo.tools;
using GestionEvent_DAL.Services;
using GestionEvent_DAL.Services.Event;
using GestionEvent_DAL.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenManager>();
builder.Services.AddTransient<SqlConnection>(pc => new SqlConnection(builder.Configuration.GetConnectionString("default")));

////builder.Services.AddAuthorization(opt => {
////    opt.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
////    opt.AddPolicy("ModoPolicy", o => o.RequireRole("Admin", "Modo"));
////    opt.AddPolicy("IsConnected", o => o.RequireAuthenticatedUser());
////});
///
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager._secretKey)),
            ValidateAudience = false

        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
