using adatGyujtoX.Modell;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace adatGyujtoX.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Downloaded();
            LoadApplication(new adatGyujtoX.App());
        }
        public void Downloaded()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file =>
            {
                string[] fileNameS = file.Url.Split('/');

                Constans.myZipFile = fileNameS[fileNameS.Length-1];
                string fileName = Constans.myZipFile;
                
                //Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();
                //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
                //return Path.Combine(ApplicationContext.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
                string valami=Path.Combine(ApplicationData.Current.LocalFolder.Path,fileName);
                var vege2 = "a";
                return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            });
            Constans.myZipPath = ApplicationData.Current.LocalFolder.Path;

        }
    }
}
