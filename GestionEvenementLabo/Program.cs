using GestionEvenementLabo.tools;
using GestionEvent_DAL.Services;
using GestionEvent_DAL.Services.Comments;
using GestionEvent_DAL.Services.Event;
using GestionEvent_DAL.Services.EventType;
using GestionEvent_DAL.Services.participate;
using GestionEvent_DAL.Services.Role;
using GestionEvent_DAL.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidAudience = "https://localhost:7020/",
        ValidIssuer = "https://localhost:7213/",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(TokenManager._secretKey)),
        ValidateAudience = true
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<TokenManager>();
builder.Services.AddScoped<EventTypeDayService>();
builder.Services.AddScoped<ParticipateService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<EventTypeService>();
//builder.Services.AddTransient<SqlConnection>(pc => new SqlConnection(builder.Configuration.GetConnectionString("default")));
builder.Services.AddTransient<SqlConnection>(pc => new SqlConnection(builder.Configuration.GetConnectionString("Maison")));

////builder.Services.AddAuthorization(opt => {
////    opt.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
////    opt.AddPolicy("ModoPolicy", o => o.RequireRole("Admin", "Modo"));
////    opt.AddPolicy("IsConnected", o => o.RequireAuthenticatedUser());
////});
///
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
    options.AddPolicy("ModoPolicy", o => o.RequireRole("Admin", "Modo"));

    options.AddPolicy("IsConnected", o => o.RequireAuthenticatedUser());
});
// Expliquer à l'api comment valider le token



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
