using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VirtualTourBlazor;
using VirtualTourBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Регистрируем наш сервис
builder.Services.AddScoped<ITourService, TourService>();

await builder.Build().RunAsync();