using BusinessLogicLayer;
using DataAccesLayer;
using FluentValidation.AspNetCore;
using ProductsMicrosService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusinessLogicLayer();
builder.Services.AddDataAccessLayer();


builder.Services.AddControllers();


// FluentValidations 
builder.Services.AddFluentValidationAutoValidation(); 

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
