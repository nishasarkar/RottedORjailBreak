using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ObjCRuntime;
using UIKit;

namespace RottedORjailBreak.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
       
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            ChkingRootedorJailBrokenDevice(app);
            return base.FinishedLaunching(app, options);
        }

        private void ChkingRootedorJailBrokenDevice(UIApplication uiApplication)
        {
            Foundation.NSUrl url = new NSUrl("cydia://");

            bool canopenurl = uiApplication.CanOpenUrl(url);

            bool isSimulator = false;

            if (ObjCRuntime.Runtime.Arch == Arch.SIMULATOR)
            {
                isSimulator = true;

            }
            if (IsJailBroken() || canopenurl || isSimulator)

            {

                System.Threading.Thread.CurrentThread.Abort();

            }
        }

        public static bool IsJailBroken()
        {

            bool IsJailBroken = false;

            try

            {

                var paths = new[]

                {

                     "/Applications/Checkra1n.app",

                     "/Applications/blackra1n.app",

                     "/Applications/Cydia.app",

                     "/Applications/Icy.app",

                     "/Applications/IntelliScreen.app",

                     "/Applications/MxTube.app",

                     "/Applications/RockApp.app",

                     "/Applications/FakeCarrier.app",

                     "/Applications/SBSettings.app",

                     "/Applications/WinterBoard.app",

                     "/private/var/lib/cydia",

                     "/private/var/tmp/cydia.log",

                     "/private/var/lib/apt",

                     "/private/var/lib/apt/",

                     "/private/var/stash",

                     "/private/var/mobile/Library",

                     "/private/var/mobile/Library/SBSettings/Themes",

                     "/System/Library/LaunchDaemons/",

                     "/System/Library/LaunchDaemons/com.saurik.Cydia.Startup.plist",

                     "/System/Library/LaunchDaemons/com.ikey.bbot.plist",

                     "/Application/Preferences.app/General.plist",

                     "/usr/libexec/sftp-server",

                     "/usr/bin/sshd",

                     "/usr/sbin/sshd",

                     "/Library/MobileSubstrate/MobileSubstrate.dylib",

                     "/Library/MobileSubstrate/DynamicLibraries",

                     "/Library/MobileSubstrate/DynamicLibraries/LiveClock.plist",

                     "/Library/MobileSubstrate/DynamicLibraries/Veency.plist",

                     "/bin/hash",

                     "/var/cache/apt",

                     "/var/lib/apt",

                     "/var/lib/cydia",

                     "/var/log/syslog",

                     "/var/tmp/cydia.log",

                     "/bin/bash",

                     "/bin/sh",

                     "/usr/libexec/ssh-keysign",

                     "/usr/sbin/sshd",

                     "/usr/bin/sshd",

                     "/etc/ssh/sshd_config",

                     "/etc/apt",

                     "/jb"

                 };

                IsJailBroken = paths.Any(System.IO.File.Exists);

                if (IsJailBroken)

                {

                    Console.WriteLine("Application can not run on jailed device");
                }

                return IsJailBroken;

            }

            catch (System.Exception e)

            {

                Console.WriteLine(e.Message);

            }

            return false;

        }
    }
}

