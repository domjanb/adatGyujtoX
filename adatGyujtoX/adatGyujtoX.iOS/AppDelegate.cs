using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using adatGyujtoX.Modell;
using Foundation;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using UIKit;


namespace adatGyujtoX.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            //Downloaded();
            Constans.myZipPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            #region For Screen Height & Width

            /*Constans.ScreenWidth = App.DisplayWidth;
            Constans.ScreenHeight = App.DisplayHeight;*/
            //App.SetScreenDimensions((int)UIScreen.MainScreen.Bounds.Height, (int)UIScreen.MainScreen.Bounds.Width);


            //Constans.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            //Constans.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            #endregion
            return base.FinishedLaunching(app, options);

        }
        /*public void Downloaded()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file =>
            {
                string fileName = (new NSUrl(file.Url, false)).LastPathComponent;
                //string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
            });
            Constans.ScreenHeight = (double)UIScreen.MainScreen.Bounds.Height;
            Constans.myZipPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            
        }*/
        
    }

}
