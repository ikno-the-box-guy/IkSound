using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IkSound;
using IkSound.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

HttpUtils.BaseUrl = builder.Configuration["ApiUrl"] ?? "";
builder.Services.AddScoped(sp => new HttpClient());

await builder.Build().RunAsync();