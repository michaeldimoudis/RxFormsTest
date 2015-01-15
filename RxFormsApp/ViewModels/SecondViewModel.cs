namespace RxFormsApp
{
    using System.Runtime.Serialization;
    using ReactiveUI;
    using Splat;

    [DataContract]
    public class SecondViewModel : ReactiveObject, IRoutableViewModel, IScreen
    {
        public SecondViewModel(IScreen hostScreen = null)
        {
            Router = new RoutingState();
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public string UrlPathSegment
        {
            get { return "Second"; }
        }

        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
    }
}