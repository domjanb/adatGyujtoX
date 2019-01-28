using System;

using Android.App;
using Android.AccessibilityServices;
using Android.OS.Storage;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.DownloadManager;
using System.IO;
using Plugin.DownloadManager.Abstractions;
using System.Linq;
using adatGyujtoX.Modell;
using adatGyujtoX.Droid;
using Android;
using Android.Support.V4.Content;
using System.Security;
using Java.Security;
using Android.Support.V4.App;

namespace adatGyujtoX.Droid
{
    [Activity(Label = "adatGyujtoX", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //Downloaded();
            Constans.myZipPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        
        /*public void Downloaded()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file =>
            {
                string fileName = Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();
                //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
                return Path.Combine(ApplicationContext.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
                //ApplicationData.Current.LocalFolder.Path
                //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
                //return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                
                //return Path.Combine(System.Environment.GetFolderPath( System.Environment.SpecialFolder.Personal), fileName);
            });
            //Constans.myZipPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Constans.myZipPath = ApplicationContext.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
        }*/
        
    }
}