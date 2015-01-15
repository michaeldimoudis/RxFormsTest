namespace RxFormsApp
{
    using System;
    using System.Net.Http;
    using Akavache;
    using ModernHttpClient;
    using ReactiveUI;
    using Splat;
    using Xamarin.Forms;
    using ReactiveUI.XamForms;

    // CoolStuff: This class and anything under it will automatically get
    // saved and restored by ReactiveUI. This is a great place to put all
    // of your startup code - think of it as the "ViewModel for your app".
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        // The Router holds the ViewModels for the back stack. Because it's
        // in this object, it will be serialized automatically.
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof (IScreen));

            // Set up Akavache
            // 
            // Akavache is a portable data serialization library that we'll use to
            // cache data that we've downloaded
            BlobCache.ApplicationName = "RxFormsApp";

            // Set up Fusillade
            //
            // Fusillade is a super cool library that will make it so that whenever
            // we issue web requests, we'll only issue 4 concurrently, and if we
            // end up issuing multiple requests to the same resource, it will
            // de-dupe them. We're saying here, that we want our *backing*
            // HttpMessageHandler to be ModernHttpClient.
            Locator.CurrentMutable.RegisterConstant(new NativeMessageHandler(), typeof (HttpMessageHandler));

            // TODO: Register new views here, then navigate to the first page 
            // in your app
            Locator.CurrentMutable.Register(() => new FirstPage(), typeof (IViewFor<FirstViewModel>));
            Locator.CurrentMutable.Register(() => new SecondPage(), typeof (IViewFor<SecondViewModel>));

            // Kick off to the first page of our app. If we don't navigate to a
            // page on startup, Xamarin Forms will get real mad (and even if it
            // didn't, our users would!)
            //Router.Navigate.Execute(new FirstViewModel(this));
        }

//        public Page CreateMainPage()
//        {
//            // NB: This returns the opening page that the platform-specific
//            // boilerplate code will look for. It will know to find us because
//            // we've registered our AppBootstrapper as an IScreen.
//            //return new RoutedViewHost();
//
//            return new ContentPage {
//                Content = new StackLayout {
//                    VerticalOptions = LayoutOptions.Center,
//                    Children = {
//                        new Label {
//                            XAlign = TextAlignment.Center,
//                            Text = "Welcome to Xamarin Forms!"
//                        }
//                    }
//                }
//            };
//        }

        public Page CreateMainPage()
        {
//            return new ContentPage {
//                Content = new StackLayout {
//                    VerticalOptions = LayoutOptions.Center,
//                    Children = {
//                        new Label {
//                            XAlign = TextAlignment.Center,
//                            Text = "Welcome to Xamarin Forms!"
//                        }
//                    }
//                }
//            };

            var tabs = new TabbedPage();

            var firstView = new FirstViewModel();
            firstView.Router.Navigate.Execute(firstView);
            var firstHost = new RoutedViewHost {
                Router = firstView.Router,
                Title = "First"
            };
            tabs.Children.Add(firstHost);

            var secondView = new SecondViewModel();
            secondView.Router.Navigate.Execute(secondView);
            var secondHost = new RoutedViewHost {
                Router = secondView.Router,
                Title = "Second"
            };
            tabs.Children.Add(secondHost);

            return tabs;
        }
    }
}

