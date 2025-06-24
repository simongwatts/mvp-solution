using MvpCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpCore.Events
{
    public class ViewReadyEvent<TView> where TView : class, IView
    {
        public TView? View { get; }
        public ViewReadyEvent(TView? view) => View = view;
    }
}
