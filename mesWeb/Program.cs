using mesWeb.Database.Entity;
using mesWeb.Entity;
using mesWeb.Repository;
using mesWeb.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository<WorkOrder>, WorkOrderRepository>();
builder.Services.AddTransient<IRepository<Manufacture>, ManufactureRepository>();
builder.Services.AddTransient<ManufactureWorkOrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/some-endpoint", (ManufactureWorkOrderService service) =>
{
    // 이 부분에서 manufactureWorkOrderService를 사용하여 로직을 수행하세요.

    // 예를 들면:
    service.AddWorkOrder(new WorkOrder
    {
        
        Description = "test",
        Product = "test",
        TargetQty = 100,
        OrderUser = "ljh",
        DueDate = default,
        ExpireDate = default,
        CreateDateTime = default,
        
    });
    
    //return Results.Ok(result);
});


app.Run();
