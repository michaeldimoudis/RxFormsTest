namespace RxFormsApp
{
    using System.Runtime.Serialization;
    using ReactiveUI;
    using Splat;

    [DataContract]
    public class FirstViewModel : ReactiveObject, IRoutableViewModel, IScreen
    {
        public FirstViewModel(IScreen hostScreen = null)
        {
            Router = new RoutingState();
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public string UrlPathSegment
        {
            get { return "First"; }
        }

        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
    }
}