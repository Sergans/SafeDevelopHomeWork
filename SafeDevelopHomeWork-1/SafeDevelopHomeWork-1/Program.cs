using SafeDevelopHomeWork_1.Services;
using SafeDevelopHomeWork_1.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // укзывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = false,
        // строка, представляющая издателя
        ValidIssuer = UserToken.Issuser,

        // будет ли валидироваться потребитель токена
        ValidateAudience = false,
        // установка потребителя токена
        ValidAudience = UserToken.Audience,
        // будет ли валидироваться время существования
        ValidateLifetime = true,

        // установка ключа безопасности
        IssuerSigningKey = UserToken.GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSingleton<CardOperation>();
builder.Services.AddSingleton<DataBase>();
builder.Services.AddSingleton<UserOperation>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeDevelop", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
