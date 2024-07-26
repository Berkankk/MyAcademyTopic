using System.Reflection;
using Topic.BusinessLayer.Abstract;
using Topic.BusinessLayer.Concrete;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Concrete;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());   // profilden miras alan t�m s�n�flar� burada kendis register i�lemi yap�yor. Automapperde yapt�klar�m�z� buradan tek tek yazmak yerine bu metot bizim yerimize yap�yor.  
builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IManuelDal, EFManuelDal>();
builder.Services.AddScoped<IManuelService, ManuelManager>();

builder.Services.AddScoped<IQuestionDal, EfQuestionDal>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>)); // generic dal generic repository de implement edildi�i i�in bu �ekilde belirttik.


builder.Services.AddDbContext<TopicContext>();


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
