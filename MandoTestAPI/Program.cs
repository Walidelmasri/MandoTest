var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); 
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ReportsMvc}/{action=Index}/{id?}"); 
});

app.Run();
