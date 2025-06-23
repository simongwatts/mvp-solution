using BlazorCounterExample;
using CounterCommon.Models;
using CounterCommon.Presenters;
using CounterCommon.Views;
using MvpCore.Events;
using MvpCore.Interfaces;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register EventAggregator for event-driven MVP
builder.Services.AddScoped<IEventPublisher, EventAggregator>();
builder.Services.AddScoped<CounterModel>();
builder.Services.AddScoped<CounterPresenter>();

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

await builder.Build().RunAsync();