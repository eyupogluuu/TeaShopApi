using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.BusinessLayer.Concrete;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Context;
using TeaShopApi.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDrinkDal,EFDrinkDal>();
builder.Services.AddScoped<IDrinkService,DrinkManager>();

builder.Services.AddScoped<IQuestionDal, EFQuestionDal>();
builder.Services.AddScoped<IQuestionService,QuestionManager >();

builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IStatisticDal, EFStatisticDal>();
builder.Services.AddScoped<IStatisticService, StatisticManager>();

builder.Services.AddDbContext<TeaContext>();
builder.Services.AddControllers();
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
