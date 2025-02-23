
namespace MvpCore.Interfaces
{
    public interface IPresenter<TView, TModel> : IDisposable
        where TView : IView
        where TModel : IModel
    {
        TView View { get; }
        TModel Model { get; }
    }
}