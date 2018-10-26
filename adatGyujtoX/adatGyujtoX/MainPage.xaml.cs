using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace adatGyujtoX
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            
            InitializeComponent();

            /// Milyen a net? 
            /// 0 nincs
            /// 1 all
            /// 2 wifi
            /// 3 mobil
            /// 4 egyeb
            ///
            //var milyenANet = 0;
            int netTipus = milyenANet();

            UsersDataAccess azonadat = new UsersDataAccess();
            int regisztrácioDarab=azonadat.GetCogAzon().Count();
            if (regisztrácioDarab == 1)
            {

            }
            else
            {
                /// ha nem egy ember van ide regisztrálva, hanem több, vagyegym, akkor delete table és a reg.xaml meghívása
                azonadat.DeleteCogAzonAll();
                if (netTipus == 2)
                {
                    //ide jön a http reg
                }
            }

            ///
            
            
            //SQLiteConnection conn = new SQLiteConnection();

            //UsersDataAccess azonadat = new UsersDataAccess();
            Console.Write("aaaa1");
            var idd=azonadat.SaveCogAzon(new Cogazon {
                uemail = "1",
                uname = "helloleo",
                upass = "1",
                userid = 1,
                usname = "1"
            });
            Console.Write("aaaa2");
            //Cogazon mostadat = new Cogazon();
            var mostadat =  azonadat.GetCogAzonAsSern(idd - 1)  ;
            if (mostadat is Cogazon)
            {
                var alfa = "aaaa";
            }
            IEnumerable<Cogazon> mostadat2 = azonadat.GetCogAzonAsSern(idd - 1);
            if (mostadat2 is Cogazon)
            {
                var alfa2 = "aaaa";
            }
            //mostadat.
            var a2 = 1;
            /*var todoData = new TodoItemDatabase("");
            todoData.SaveItemAsync(new TodoItem
            {
                Name = "alfa",
                Notes = "aaa"
            });
            Console.Write(todoData.ToString());
            App.Database.SaveItemAsync(new TodoItem
            {
                Name = "alfa",
                Notes = "aaa"
            });*/
            Console.Write("aaaa3");
            var myLayout = new StackLayout();
            Console.Write("aaaa4");



            var fejlecL = new StackLayout();
            fejlecL.BackgroundColor = Color.Aqua;
            fejlecL.HorizontalOptions = LayoutOptions.FillAndExpand;
            fejlecL.Padding = 20;

            var fejlecD = new Label();
            fejlecD.Text = "Cognative Touchpoint";
            fejlecD.HorizontalOptions = LayoutOptions.Center;

            fejlecL.Children.Add(fejlecD);

            myLayout.Children.Add(fejlecL);


            var btn = new Button();

            if (mostadat2.Count() == 1)
            {
                foreach (var all in mostadat2)
                {
                    btn.Text = all.uname;
                }
            }
            

            


            //var idd = 0;
            //var mosttodo = new TodoItem();
            //TodoItem mosttodo =  todoData.GetItemAsync(idd).Result; 
            //btn.Text = mosttodo.Name;
            btn.HorizontalOptions = LayoutOptions.Center;
            btn.VerticalOptions = LayoutOptions.Center;
            myLayout.Children.Add(btn);


            Button button = new Button
            {
                Text = "Navigate!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            button.Clicked += async (sender, args) =>
            {
                //await Navigation.PushAsync(new HelloXamlPage());
            };
            
            
            Content = myLayout;
        }

        private int milyenANet()
        {
            int vissza = 0;
            if (DoIHaveInternet())
            {
                var wifi = Plugin.Connectivity.Abstractions.ConnectionType.WiFi;
                var mobilnet = Plugin.Connectivity.Abstractions.ConnectionType.Cellular;
                var connectionTypes = CrossConnectivity.Current.ConnectionTypes;
                if (connectionTypes.Contains(wifi) && connectionTypes.Contains(mobilnet))
                {
                    vissza = 1;
                }
                else if (connectionTypes.Contains(wifi))
                {
                    vissza = 2;
                }
                else if (connectionTypes.Contains(mobilnet))
                {
                    vissza = 3;
                }
                else 
                {
                    vissza = 4;
                }
            }
            return vissza;

        }

        public bool DoIHaveInternet()
        {

            
            return CrossConnectivity.Current.IsConnected;

        }

    }
}
