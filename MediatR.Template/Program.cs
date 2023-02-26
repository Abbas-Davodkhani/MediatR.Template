using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Template.AutoMapperProfiles;
using MediatR.Template.Behavior;
using MediatR.Template.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>
    (option => option.UseSqlServer(@"Server=.;Database=MediaterDb;Trusted_Connection=True;TrustServerCertificate=True;"));


// deprecated
//builder.Services.AddMvc().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Customer>());
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddFluentValidation().AddValidatorsFromAssemblyContaining<Customer>();
var configuration = new MapperConfiguration(cfg =>
{
    //cfg.CreateMap<Customer, CustomerDto>();
    cfg.AddProfile<DomainProfile>();
});

builder.Services.AddAutoMapper(c =>
{
    c.AddProfile<DomainProfile>();
});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>) , typeof(RequestPerformanceBehavior<,>));

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
