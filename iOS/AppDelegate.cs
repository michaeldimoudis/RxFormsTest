using Foundation;
using UIKit;

using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using RxFormsApp;
using Xamarin.Forms;

namespace RxFormsApp.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        UIWindow window;
        AutoSuspendHelper suspendHelper;

        public AppDelegate()
        {
            RxApp.SuspensionHost.CreateNewAppState = () => new AppBootstrapper();
        }

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init ();
            RxApp.SuspensionHost.SetupDefaultSuspendResume();

            //LoadApplication (new App ());

            suspendHelper = new AutoSuspendHelper(this);
            suspendHelper.FinishedLaunching(app, options);

            window = new UIWindow (UIScreen.MainScreen.Bounds);
            var bootstrapper = RxApp.SuspensionHost.GetAppState<AppBootstrapper>();

            window.RootViewController = bootstrapper.CreateMainPage().CreateViewController();
            window.MakeKeyAndVisible ();

            //return base.FinishedLaunching (app, options);
            return true;
        }

        public override void DidEnterBackground(UIApplication application)
        {
            suspendHelper.DidEnterBackground(application);
        }

        public override void OnActivated(UIApplication application)
        {
            suspendHelper.OnActivated(application);
        }
    }
}

