using Mapsui;
using Mapsui.Tiling;
using Mapsui.UI.iOS;

namespace iOSMapsuiTest;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        var vc = new UIViewController();

        var button = new UIButton(Window!.Frame)
        {
            BackgroundColor = UIColor.SystemBackground,
            AutoresizingMask = UIViewAutoresizing.All,
        };
        button.SetTitle("click", UIControlState.Normal);
        button.SetTitleColor(UIColor.Green, UIControlState.Normal);
        button.TouchDown += (sender, e) =>
        { 
            var storyboard = UIStoryboard.FromName("MainStoryboard", null);  
            var contoller = storyboard.InstantiateInitialViewController();
            vc?.NavigationController.PushViewController(contoller, true);
        };
        vc.View!.AddSubview(button);
        
        Window.RootViewController = new UINavigationController(vc);
        
        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}