using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LojaVirtualWeb;
using LojaVirtualWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IProductService, ProductService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseURL = "http://localhost:5257";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseURL) });

await builder.Build().RunAsync();
