using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using Core.DependencyResolvers;
using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//Add Autofac support.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>
    (builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    }
    );



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//We are using autofac. There is no need to use microsoft's IoC container.
//builder.Services.AddSingleton<ICarDal, EfCarDal>();
//builder.Services.AddSingleton<ICarService, CarManager>();

//Lets use the extenteded IoC Container.
builder.Services.AddDependencyResolver(new Core.Utilities.IoC.ICoreModule[]
{
    new CoreModule()

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
