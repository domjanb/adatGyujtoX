using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Connectivity;
using Xamarin.Forms.Internals;
using System.Diagnostics;

namespace adatGyujtoX
{
    public partial class MainPage : ContentPage
    {
        
        public Entry[] valaszok = new Entry[5];
        //String[] vs;

        Button reggomb;
        public MainPage()
        {

            InitializeComponent();

            var myLayout = new StackLayout();

            var fejlecL = new StackLayout();
            fejlecL.BackgroundColor = Color.Aqua;
            fejlecL.HorizontalOptions = LayoutOptions.FillAndExpand;
            fejlecL.Padding = 20;

            var fejlecD = new Label();
            fejlecD.Text = "Cognative Touchpoint";
            fejlecD.HorizontalOptions = LayoutOptions.Center;

            fejlecL.Children.Add(fejlecD);

            myLayout.Children.Add(fejlecL);




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
            int regisztrácioDarab = azonadat.GetCogAzon().Count();
            if (regisztrácioDarab == 1)
            {

            }
            else
            {

                /// ha nem egy ember van ide regisztrálva, hanem több, vagyegym, akkor delete table és a reg.xaml meghívása
                azonadat.DeleteCogAzonAll();

                //regform
                if (netTipus != 0)
                {
                    //var regForm = new Grid { ColumnSpacing = 5 };
                    var regForm = new Grid();
                    regForm.HorizontalOptions = LayoutOptions.Center;
                    //regForm.BackgroundColor = Color.LightGray;
                    regForm.Padding = 20;

                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    //regForm.ColumnDefinitions.w
                    var zeroC = new Label { Text = "", HorizontalTextAlignment = TextAlignment.End };
                    var nameC = new Label { Text = "Name:", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center };
                    var name = new Entry { Placeholder = "Name:" };
                    name.TextChanged += OnEntryTextChanged;
                    //name.PropertyChanging=
                    var name2C = new Label { Text = "Surename:", HorizontalTextAlignment = TextAlignment.End };
                    var name2 = new Entry { Placeholder = "Surename:" };
                    var codeC = new Label { Text = "Code:", HorizontalTextAlignment = TextAlignment.End };
                    var code = new Entry { Placeholder = "Code:" ,Keyboard=Keyboard.Numeric};
                    var passC = new Label { Text = "Password:", HorizontalTextAlignment = TextAlignment.End };
                    var pass = new Entry { Placeholder = "Password:",IsPassword=true };
                    var emilC = new Label { Text = "E-mail:", HorizontalTextAlignment = TextAlignment.End };
                    var emil = new Entry { Placeholder = "E-mail:" };
                    var regButton = new Button { Text = "Registration:" };
                    regButton.IsVisible = false;

                    reggomb = regButton;
                    valaszok[0] = name;
                    valaszok[1] = name2;
                    valaszok[2] = code;
                    valaszok[3] = pass;
                    valaszok[4] = emil;

                    //vs.in
                    regForm.Children.Add(zeroC, 0, 0);
                    regForm.Children.Add(nameC, 1, 0);
                    regForm.Children.Add(name, 2, 0);
                    regForm.Children.Add(name2C, 1, 1);
                    regForm.Children.Add(name2, 2, 1);
                    regForm.Children.Add(codeC, 1, 2);
                    regForm.Children.Add(code, 2, 2);
                    regForm.Children.Add(passC, 1, 3);
                    regForm.Children.Add(pass, 2, 3);
                    regForm.Children.Add(emilC, 1, 4);
                    regForm.Children.Add(emil, 2, 4);
                    regForm.Children.Add(regButton, 2, 6);
                    //Grid.SetColumnSpan(regButton, 1);




                    myLayout.Children.Add(regForm);

                    //ide jön a http reg
                }
            }

            bazsiInit(myLayout, azonadat);

            Content = myLayout;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            //
            var oldText = e.OldTextValue;
            var newText = e.NewTextValue;

            var inputBox = (Entry)sender;
            Boolean nyert = true;
            for (var i=0; i < valaszok.Length; i++)
            {
                if (Length(BTrim(valaszok[i].Text)) == 0)
                {

                    nyert = false;
                    Debug.WriteLine("aa");
                    Console.WriteLine("hellololllll");
                    Debug.WriteLine(i);
                    var ho = Length(BTrim(valaszok[i].Text));
                    Debug.WriteLine(ho);
                }
            }

            if (nyert)
            {
                reggomb.IsVisible = true;
            }
            else
            {
                reggomb.IsVisible = false;
            }

            var alff = "aaa";


        }

        private int Length(string v)
        {
            int vissza = 0;
            if (v != null)
            {
                vissza = v.Length;
            }

            return vissza;
        }

        
        private string BTrim(string text)
        {
            String vissza = text;
            if (text != null)
            {
                if (text.Length > 0)
                {
                    var text2 = text.TrimEnd(' ');
                    vissza = text2.TrimStart(' ');
                }
            }
            

            return vissza;
        }

        private static void bazsiInit(StackLayout myLayout, UsersDataAccess azonadat)
        {
            ///


            //SQLiteConnection conn = new SQLiteConnection();

            //UsersDataAccess azonadat = new UsersDataAccess();
            Console.Write("aaaa1");
            var idd = azonadat.SaveCogAzon(new Cogazon
            {
                uemail = "1",
                uname = "helloleo",
                upass = "1",
                userid = 1,
                usname = "1"
            });
            var idd2 = azonadat.SaveCogAzon(new Cogazon
            {
                uemail = "12",
                uname = "helloleo",
                upass = "12",
                userid = 12,
                usname = "12"
            });
            Console.Write("aaaa2");
            //Cogazon mostadat = new Cogazon();
            var mostadat = azonadat.GetCogAzonAsSern(idd - 1);
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
