using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Birisi api den product istedi�inde Iproduct � newliyor ba��ml�l���n� da new liyor 
builder.Services.AddSingleton<IProductService,ProductManager>();
//product manager productdal a ba�ml� oldu�u i�in arkada EfProductDal� new liyor ve referans tutuyor 1000 client iste�ini kar��layabilir.
builder.Services.AddSingleton<IProductDal, EfProductDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
