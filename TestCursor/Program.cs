//using Products;
//using TestCursor.Components;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();
//builder.Services.AddRazorPages();
//// Register the IProcessProducts service
//builder.Services.AddScoped<IProcessProducts, TestProducts>();


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

////added the following for DI injection
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.UseAntiforgery();

////app.MapStaticAssets();
////app.MapRazorComponents<App>()
////    .AddInteractiveServerRenderMode();

//app.Run();


using Products;
using TestCursor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
// Register the IProcessProducts service
builder.Services.AddScoped<IProcessProducts, TestProducts>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();
app.MapFallbackToPage("/_Host");

app.Run();