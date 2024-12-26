using AppShop.Business;
using AppShop.Business.Entity;
using AppShop.Business.ErrorHandle;
using AppShop.Business.IService;
using AppShop.Business.Mapping;
using AppShop.Business.Service;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppShopDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppShopDBContext>()
  .AddErrorDescriber<UserIdentityError>();
builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 0;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3600);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

});
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderBuyService, OrderBuyService>();
builder.Services.AddScoped<ILogService, LogService>();
//builder.Services.AddScoped<ICookiService,CookiService>();
builder.Services.AddScoped<IOrderBuyStatuesService, OrderBuyStatuesService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});



var app = builder.Build();
app.UseCors("CORSPolicy");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapIdentityApi<User>();
app.MapFallbackToFile("/index.html");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();
app.UseCors("myAppCors");
app.Run();
