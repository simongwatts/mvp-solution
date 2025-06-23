using CounterCommon.Events;
using CounterCommon.Views;
using MvpCore.Events;

namespace CounterExample.Views
{
    public partial class CounterForm : Form, ICounterView
    {
        private readonly IEventPublisher _eventBus;

        public CounterForm(IEventPublisher eventBus)
        {
            _eventBus = eventBus;
            InitializeComponent();
            btnIncrement.Click += (s, e) =>
                _eventBus.Publish(new IncrementRequestedEvent());
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateCount(int count) => lblCount.Text = count.ToString();
    }
}