
using AiAgent;
using Products;
using TestCursor.Components;


var builder = WebApplication.CreateBuilder(args);

var openAiApiKey = builder.Configuration["OpenAiClient:ApiKey"];
var shopifyApiToken = builder.Configuration["Shopify:AccessToken"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
// Register the IProcessProducts service
//builder.Services.AddScoped<IProcessProducts, ProcessProductsForSpotify>();
builder.Services.AddScoped<IProcessProducts>(sp => new ProcessProductsForShopify(shopifyApiToken));
//builder.Services.AddScoped<IAiAgent, TestAiAgent>();
builder.Services.AddScoped<IAiAgent>(sp => new OpenAiClient(openAiApiKey));

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