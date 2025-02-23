using MvpCore.Events;
using CounterExample.Models;
using CounterExample.Presenters;
using CounterExample.Views;

namespace CounterExample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize dependencies
            var eventBus = new EventAggregator();
            var view = new CounterForm(eventBus);
            var model = new CounterModel(eventBus);

            // Instantiate presenter (ties view+model+events together)
            var presenter = new CounterPresenter(view, model, eventBus);

            Application.Run(view);
        }
    }
}