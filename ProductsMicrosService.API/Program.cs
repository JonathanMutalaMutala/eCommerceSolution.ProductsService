using BusinessLogicLayer;
using DataAccesLayer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using ProductsMicrosService.API.APIEndpoints;
using ProductsMicrosService.API.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusinessLogicLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);


builder.Services.AddControllers();


// FluentValidations 
builder.Services.AddFluentValidationAutoValidation();


builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.IncludeFields = true);

//Add model binder to read values from JSON to enum
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add swagger services 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Cors 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyOrigin()
        .AllowAnyHeader();
    });
}); 


var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

// Cors 
app.UseCors();


// Swagger
app.UseSwagger();
app.UseSwaggerUI();




app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.MapProductAPIEndPoints();

app.Run();
