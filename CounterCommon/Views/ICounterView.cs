using MvpCore.Interfaces;

namespace CounterCommon.Views
{
    public interface ICounterView : IView
    {
        void UpdateCount(int count);
    }
}
