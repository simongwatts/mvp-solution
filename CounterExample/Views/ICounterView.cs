using MvpCore.Interfaces;

namespace CounterExample.Views
{
    public interface ICounterView : IView
    {
        void UpdateCount(int count);
    }
}
