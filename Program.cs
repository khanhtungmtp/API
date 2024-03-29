using API.Configurations;
using API.Helpers;
using API.Dtos.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);
// Add Authentication
builder.Services.AddAuthenticationConfigufation(builder.Configuration);
// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();
// RepositoryAccessor and Service
builder.Services.AddDependencyInjectionConfiguration(typeof(Program));
// Add swagger
builder.Services.AddSwaggerGenConfiguration();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Exception Handling Middleware Error
builder.Services.AddTransient<JwtMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();