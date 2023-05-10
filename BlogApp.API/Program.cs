using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Repository;
using BlogApp.Repository.Repositories;
using BlogApp.Service.Mapping;
using BlogApp.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers().AddJsonOptions(options => json dosyadaki nesneleri döngüsünü kýran yapý
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    options.JsonSerializerOptions.WriteIndented = true;
//});
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddDbContext<BlogDbContext>(op=> op.UseSqlServer(@"Server=DESKTOP-8JBJMG8\SQLEXPRESS;Database=BlogAppDb;Integrated Security=true; TrustServerCertificate=True"));
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IYazarRepository), typeof(YazarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IYorumRepository), typeof(YorumRepository));


builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IBlogService), typeof(BlogService));
builder.Services.AddScoped(typeof(IYazarService), typeof(YazarService));
builder.Services.AddScoped(typeof(IYorumService), typeof(YorumService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddScoped(typeof(IContactService), typeof(ContactService));








// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(op =>
{
    op.AddDefaultPolicy(option =>
    {
        option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
