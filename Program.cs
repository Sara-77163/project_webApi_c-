using Microsoft.EntityFrameworkCore;
using final_project.DAL;
using System.Text.Json.Serialization;
using final_project.BLL;
using final_project;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ChinaSaleContext>(options =>
{

    if (connectionString != null)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }
});
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddScoped<IDonorServices, DonorServices>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IGiftServices, GiftServices>();
builder.Services.AddScoped<IGiftDAL, GiftDal>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(DonorProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
