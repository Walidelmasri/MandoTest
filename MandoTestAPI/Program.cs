var builder = WebApplication.CreateBuilder(args);

// Add services (ONLY the ones you need)
builder.Services.AddControllers(); // Enable MVC Controllers
builder.Services.AddEndpointsApiExplorer(); // Enable API endpoints
// builder.Services.AddSwaggerGen(); // Enable Swagger (if needed)

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Maps Controllers (your APIs)

app.Run();
