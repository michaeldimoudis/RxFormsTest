namespace RxFormsApp
{
    using ReactiveUI;
    using Xamarin.Forms;

    public partial class SecondPage : ContentPage, IViewFor<SecondViewModel>
    {
        public static readonly BindableProperty ViewModelProperty =
            BindableProperty.Create<SecondPage, SecondViewModel>(x => x.ViewModel,
                default(SecondViewModel));

        public SecondPage()
        {
            InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SecondViewModel) value; }
        }

        public SecondViewModel ViewModel
        {
            get { return (SecondViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}