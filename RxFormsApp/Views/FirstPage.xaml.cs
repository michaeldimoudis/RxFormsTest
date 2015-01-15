namespace RxFormsApp
{
    using ReactiveUI;
    using Xamarin.Forms;

    public partial class FirstPage : ContentPage, IViewFor<FirstViewModel>
    {
        public static readonly BindableProperty ViewModelProperty =
            BindableProperty.Create<FirstPage, FirstViewModel>(x => x.ViewModel,
                default(FirstViewModel));

        public FirstPage()
        {
            InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (FirstViewModel) value; }
        }

        public FirstViewModel ViewModel
        {
            get { return (FirstViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}