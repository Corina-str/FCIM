using BiroulSindicalFCIM.Client.Services;
using FCIM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("FCIM.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FCIM.ServerAPI"));

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IEduCardService, EduCardService>();
builder.Services.AddScoped<IMessageService, MessageService>();


builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
