using Microsoft.ReactNative;
using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RNWPlayground
{
    sealed partial class App : ReactApplication
    {
        public static string appState;
        public App()
        {
#if BUNDLE
            JavaScriptBundleFile = "index.windows";
            InstanceSet tings.UseWebDebugger = false;
            InstanceSettings.UseFastRefresh = false;
#else
            JavaScriptBundleFile = "index";
            InstanceSettings.UseWebDebugger = true;
            InstanceSettings.UseFastRefresh = true;
#endif

#if DEBUG
            InstanceSettings.UseDeveloperSupport = true;
#else
            InstanceSettings.UseDeveloperSupport = false;
#endif

            Microsoft.ReactNative.Managed.AutolinkedNativeModules.RegisterAutolinkedNativeModulePackages(PackageProviders); // Includes any autolinked modules

            PackageProviders.Add(new Microsoft.ReactNative.Managed.ReactPackageProvider());
            PackageProviders.Add(new ReactPackageProvider());

            this.EnteredBackground += (object sender, EnteredBackgroundEventArgs args) =>
            {
                appState = "background";
                Debug.WriteLine(appState);
            };

            this.LeavingBackground += (object sender, LeavingBackgroundEventArgs args) =>
            {
                appState = "active";
                Debug.WriteLine(appState);
            };

            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            base.OnLaunched(e);
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
            Window.Current.Activate();
        }
    }
}
