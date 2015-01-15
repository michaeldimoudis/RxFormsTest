using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using RxFormsApp;
using Akavache;
using Xamarin.Forms.Platform.Android;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace RxFormsApp.Droid
{
    [Activity (Label = "RxFormsApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
//            base.OnCreate (bundle);
//
//            global::Xamarin.Forms.Forms.Init (this, bundle);
//
//            LoadApplication (new App ());


            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init (this, bundle);

            // NB: This is the worst way ever to handle UserErrors and definitely *not*
            // best practice. Help your users out!
            UserError.RegisterHandler(ue => {
                var toast = Toast.MakeText(this, ue.ErrorMessage, ToastLength.Short);
                toast.Show();

                return Observable.Return(RecoveryOptionResult.CancelOperation);
            });

            var bootstrapper = RxApp.SuspensionHost.GetAppState<AppBootstrapper>();
            this.SetPage(bootstrapper.CreateMainPage());
            //LoadApplication (bootstrapper.CreateMainPage());
        }
    }
}

