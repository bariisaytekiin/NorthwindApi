using Microsoft.EntityFrameworkCore;
using NorthwindApi.Models.Context;
using NorthwindApi.Repository;
using NorthwindApi.Service;

var builder = WebApplication.CreateBuilder(args);


//Services

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("NorthwindConnection");

builder.Services.AddDbContext<northwndContext>(options => options.UseSqlServer(connectionString));

//Addscope inteface dahil etme

builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();


//cors
builder.Services.AddCors(x =>
{
    x.AddPolicy("NorthwindPolicy", options =>
    {
        options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//App
var app = builder.Build();

app.UseRouting();
app.UseCors("NorthwindPolicy");


app.UseEndpoints(endpoints =>

{
    endpoints.MapControllerRoute(
        name:"Default",
        pattern:"api/{Controller}/{Action}/{id?}"
        );//Varsayýlan endpoint en alltta olmalý
}

);

app.Run();
