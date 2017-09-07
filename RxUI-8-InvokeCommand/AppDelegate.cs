using System.Diagnostics;
using Foundation;
using Splat;
using UIKit;

namespace RxUI8InvokeCommand.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Locator.CurrentMutable.RegisterConstant(new DebugLogger(), typeof(ILogger));

            return true;
        }

        public class DebugLogger : ILogger
        {
            public LogLevel Level { get; set; }

            public void Write(string message, LogLevel logLevel)
            {
                Debug.WriteLineIf(logLevel >= Level, message);
            }
        }
    }
}

