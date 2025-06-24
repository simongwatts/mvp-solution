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
//builder.Services.AddScoped<IEventPublisher, EventAggregator>();
//builder.Services.AddScoped<CounterModel>();
//builder.Services.AddScoped<CounterPresenter>();

// Register EventBus
builder.Services.AddSingleton<IEventPublisher, EventAggregator>();

// Register CounterModel
builder.Services.AddSingleton<CounterModel>();

// Manually instantiate the presenter and register it
builder.Services.AddSingleton<CounterPresenter>(sp =>
{
    var model = sp.GetRequiredService<CounterModel>();
    var eventBus = sp.GetRequiredService<IEventPublisher>();
    var presenter = new CounterPresenter(model, eventBus);
    presenter.Initialize(); // Ensure subscriptions are set up
    return presenter;
});

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

//await builder.Build().RunAsync();

var host = builder.Build();

// This line will force the DI container to create and initialize the CounterPresenter singleton
var presenter = host.Services.GetRequiredService<CounterPresenter>();

await host.RunAsync();