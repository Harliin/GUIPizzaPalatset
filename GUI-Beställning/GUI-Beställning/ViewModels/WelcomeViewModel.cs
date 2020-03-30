using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class WelcomeViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "WelcomeMenu";

        public IScreen HostScreen { get; }

        #endregion

        public WelcomeViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
