using AppShop.Business;
using AppShop.Business.Mapping;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppShopDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderBuyService, OrderBuyService>();
builder.Services.AddScoped<ILogService,LogService>();

builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


//var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("myAppCors", policy =>
//    {
//        policy.WithOrigins(allowedOrigin)
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//    });
//});

var app = builder.Build();
app.UseCors("CORSPolicy");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("myAppCors");
app.Run();
