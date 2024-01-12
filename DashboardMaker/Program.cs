using DashboardMaker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();

	// Enable middleware to serve Swagger-UI
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});
}
else
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Custom Middleware for redirecting based on authentication
app.Use(async (context, next) =>
{
	var path = context.Request.Path.Value;

	// Check if user is authenticated
	if (context.User.Identity.IsAuthenticated)
	{
		context.Response.Redirect("/Dashboard/Index");
	}
	else
	{
		if (path == "/LoggedInIndex") // Authenticated user's index page
		{
			context.Response.Redirect("/"); // Redirect to default page
			return;
		}
	}

	await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
	// If the request path is the root (default page)
	if (context.Request.Path == "/")
	{
		if (context.User.Identity.IsAuthenticated)
		{
			// Redirect to a different page if the user is authenticated
			context.Response.Redirect("/Dashboard/Index");
		}
		else
		{
			// Redirect to login or home page if the user is not authenticated
			context.Response.Redirect("/Home");
		}
	}
	else
	{
		await next.Invoke();
	}
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
