using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title="TestAPI",
            Description="my first api",
            TermsOfService= new Uri("https://localhost:7027/swagger/index.html"),
            Contact = new OpenApiContact
            {
                Name="Mohamed",
                Email="test@gmail.com",
                Url= new Uri("https://localhost:7027/swagger/index.html")
            },
            License = new OpenApiLicense
            {
                Name="My License",
                Url = new Uri("https://localhost:7027/swagger/index.html")
            }

        });


        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name="Authorization",
            Type= SecuritySchemeType.ApiKey,
            Scheme= "Bearer",
            BearerFormat="JWT",
            In =ParameterLocation.Header,
            Description ="Enter JWT Key :"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id= "Bearer"
                    },
                    Name="Bearer",
                    In =ParameterLocation.Header,
            },new List<string>()
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
