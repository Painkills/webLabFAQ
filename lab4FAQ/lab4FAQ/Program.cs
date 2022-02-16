using lab5FAQ.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// We added this in class for some reason
builder.Services.AddRouting(options =>
{
    options.AppendTrailingSlash = true;
    options.LowercaseUrls = true;
});

// Database connection: we added this
builder.Services.AddDbContext<FaqContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FaqsContext")));



var app = builder.Build();

// Configure the HTTP request pipeline.
// removed a thing here, and added the two below.
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
        name: "topic_category",
        pattern: "{controller=Home}/{action=Index}/topic/{topic}/category/{category}");

    endpoints.MapControllerRoute(
        name: "category",
        pattern: "{controller=Home}/{action=Index}/category/{category}");

    endpoints.MapControllerRoute(
        name: "topic",
        pattern: "{controller=Home}/{action=Index}/topic/{topic}");

    endpoints.MapControllerRoute(
        name: "topic",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
