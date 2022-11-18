using Microsoft.AspNetCore.Authentication;
using PylabsStudentMS.Factory;
using PylabsStudentMS.Factory.IFactory;
using PylabsStudentMS.Helpers;
using PylabsStudentMS.Services;
using PylabsStudentMS.Services.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExamResultService, ExamResultService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExamFactory, ExamFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
