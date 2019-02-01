using System.Globalization;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace adatGyujtoX
{
    public partial class App : Application
    {
        /*public static int DisplayWidth { get; set; }
        public static int DisplayHeight { get; set; }*/
        //static TodoItemDatabase database;
        /*public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }*/
        public App()
        {
            //InitializeComponent();
            //TResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
