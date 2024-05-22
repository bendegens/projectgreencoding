using Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapGet("/{path}/greenframe-confirm-file.txt", async (context) =>
{
    var path = context.Request.RouteValues["path"]?.ToString();
    var filePath = Path.Combine(app.Environment.WebRootPath, "GreenFrame", path, "greenframe-confirm-file.txt");

    if (File.Exists(filePath))
    {
        var fileContent = await File.ReadAllTextAsync(filePath);
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(fileContent);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("File not found.");
    }
});

app.UseAntiforgery();

app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
