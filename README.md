# RxFormsTest ReactiveUI Xamarin Forms (Unified API) Test - CRASHING

After updating to Xamarin Unified API it works fine in the iOS Simulator, however deploying to an iPhone it always crashes in AppDelegate on RxApp.SuspensionHost.SetupDefaultSuspendResume();

Any ideas? I believe this must be a Xamarin bug? 1.3.0 non unified worked a treat.

The error is below:

System.ExecutionEngineException: Attempting to JIT compile method 'System.Reactive.Linq.QueryLanguage:Switch<System.Reactive.Unit> (System.IObservable`1<System.IObservable`1<System.Reactive.Unit>>)' while running with --aot-only. See http://docs.xamarin.com/ios/about/limitations for more information.

  at at (wrapper managed-to-native) object:__icall_wrapper_mono_helper_compile_generic_method (object,intptr,intptr)
  at System.Reactive.Linq.Observable.Switch[Unit] (IObservable`1 sources) [0x00000] in <filename unknown>:0
  at ReactiveUI.SuspensionHost.get_ShouldInvalidateState () [0x00000] in /Users/paul/code/reactiveui/reactiveui/ReactiveUI/MobileLifecycle.cs:38
  at ReactiveUI.SuspensionHostExtensions.SetupDefaultSuspendResume (ISuspensionHost This, ISuspensionDriver driver) [0x00038] in /Users/paul/code/reactiveui/reactiveui/ReactiveUI/MobileLifecycle.cs:110
  at RxFormsApp.iOS.AppDelegate.FinishedLaunching (UIKit.UIApplication app, Foundation.NSDictionary options) [0x0000c] in /Users/michael/Projects/RxFormsApp/iOS/AppDelegate.cs:28
  at at (wrapper managed-to-native) UIKit.UIApplication:UIApplicationMain (int,string[],intptr,intptr)
  at UIKit.UIApplication.Main (System.String[] args, IntPtr principal, IntPtr delegate) [0x00005] in /Developer/MonoTouch/Source/monotouch/src/UIKit/UIApplication.cs:62
  at UIKit.UIApplication.Main (System.String[] args, System.String principalClassName, System.String delegateClassName) [0x0001c] in /Developer/MonoTouch/Source/monotouch/src/UIKit/UIApplication.cs:45
  at RxFormsApp.iOS.Application.Main (System.String[] args) [0x00008] in /Users/michael/Projects/RxFormsApp/iOS/Main.cs:17

