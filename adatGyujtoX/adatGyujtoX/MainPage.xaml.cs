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
using adatGyujtoX.Data;
using System.Net.Http;
using Newtonsoft.Json;
using adatGyujtoX.myDataBase;

namespace adatGyujtoX
{
    public partial class MainPage : ContentPage
    {
        
        
        List<Entry> valaszok = new List<Entry>();
        //String[] vs;

        Button reggomb;
        private RestApiModell vissza;
        private Button[] buttons;
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

            UsersDataAccess adatBazis = new UsersDataAccess();
            int regisztrácioDarab = adatBazis.GetCogAzon().Count();
            if (regisztrácioDarab == 1)
            {

            }
            else
            {

                /// ha nem egy ember van ide regisztrálva, hanem több, vagyegym, akkor delete table és a reg.xaml meghívása
                adatBazis.DeleteCogAzonAll();

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
                    var name2C = new Label { Text = "Surename:", HorizontalTextAlignment = TextAlignment.End };
                    var name2 = new Entry { Placeholder = "Surename:" };
                    name2.TextChanged += OnEntryTextChanged;
                    var codeC = new Label { Text = "Code:", HorizontalTextAlignment = TextAlignment.End };
                    var code = new Entry { Placeholder = "Code:" ,Keyboard=Keyboard.Numeric};
                    code.TextChanged += OnEntryTextChanged;
                    var passC = new Label { Text = "Password:", HorizontalTextAlignment = TextAlignment.End };
                    var pass = new Entry { Placeholder = "Password:",IsPassword=true };
                    pass.TextChanged += OnEntryTextChanged;
                    var emilC = new Label { Text = "E-mail:", HorizontalTextAlignment = TextAlignment.End };
                    var emil = new Entry { Placeholder = "E-mail:" };
                    emil.TextChanged += OnEntryTextChanged;
                    var regButton = new Button { Text = "Registration:" };
                    regButton.IsVisible = false;
                    //regButton.Clicked +=await regButtonClickAsync;
                    regButton.Clicked += async (sender, e) =>
                    {
                        User user = new User();
                        user.user_name = valaszok[0].Text;
                        user.user_surnamed = valaszok[1].Text;
                        user.user_kod = valaszok[2].Text;
                        user.user_password = valaszok[3].Text;
                        user.user_emil = valaszok[4].Text;
                        var rs = new Data.RestService();
                        vissza = await rs.Reggi(user);
                        if (vissza.error)
                        {

                            name.IsVisible = false;
                            name2.IsVisible = false;
                            emil.IsVisible = false;
                            code.IsVisible = false;
                            pass.IsVisible = false;
                            nameC.IsVisible = false;
                            name2C.IsVisible = false;
                            emilC.IsVisible = false;
                            //codeC.IsVisible = false;
                            //passC.IsVisible = false;
                            //regButton.IsVisible = false;
                            
                            myLayout.Children.Remove(regForm);
                            var scroll = new ScrollView();
                            

                            var stack = new StackLayout();
                            scroll.Content = stack;
                            var regForm2 = new Grid();
                            regForm2.HorizontalOptions = LayoutOptions.Center;
                            //regForm2.BackgroundColor = Color.LightGray;
                            regForm2.Padding = 5;
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                            regForm2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

                            for (int i=0; i<vissza.darab;i++)
                            {
                                var ReferenceDate = new DateTime(1970, 1, 1);
                                DateTime CacheUtcTime = ReferenceDate.AddSeconds(Convert.ToInt64(vissza.kerdivadat[i].kerdiv2_le));

                                adatBazis.DeleteCogAzonAll();
                                var idd = adatBazis.SaveCogDataKerdiv(new Cogkerdiv
                                {
                                    kerdiv1nev = vissza.kerdivadat[i].kerdiv1_nev,
                                    kerdiv1ver = vissza.kerdivadat[i].kerdiv1_ver,
                                    kerdivtitle = vissza.kerdivadat[i].kerdiv1_title,
                                    kerdivtip = Convert.ToInt16(vissza.kerdivadat[i].kerdivtip),
                                    projid = Convert.ToInt16(vissza.kerdivadat[i].proj_id),
                                    fuggv_par = Convert.ToInt16(vissza.kerdivadat[i].fugg_par),
                                    fuggv_par_ertek = Convert.ToInt16(vissza.kerdivadat[i].fugg_par_ertek),
                                    fuggv_poj = Convert.ToInt16(vissza.kerdivadat[i].fugg_proj),
                                    kerdivdate = CacheUtcTime


                                });
                                var buttonM = new Button();
                                buttonM.Text = vissza.kerdivadat[i].kerdiv1_title;
                                regForm2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                                regForm2.Children.Add(buttonM, 1, i);



                                //Debug.WriteLine(Convert.ToDateTime(vissza.kerdivadat[i].kerdiv2_le));
                            }
                            
                            stack.Children.Add(regForm2);
                            myLayout.Children.Add(scroll);

                        }
                        //var aa = vissza.getError();
                        //var bb = vissza.getMessage();
                        var cc = vissza.message;
                        
                        //var visszatrue= vissza.Rootobject.error;
                        Debug.WriteLine("vlasz " + Convert.ToString(vissza));
                        var a = "";
                    }; 
                    reggomb = regButton;
                    
                    valaszok.Add( name);
                    valaszok.Add( name2);
                    valaszok.Add( code);
                    valaszok.Add(pass);
                    valaszok.Add(emil);
                    
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

            bazsiInit(myLayout, adatBazis);

            Content = myLayout;
        }

        private void gombEllAll()
        {
            throw new NotImplementedException();
        }

        private async Task regButtonClickAsync(object sender, EventArgs e)
        {

            DisplayAlert("Figyelem", "Ide jon a reggisszt", "ok", "megsem");
            


            /*var name = valaszok[0].Text;
            var name2 = valaszok[1].Text;
            var code = valaszok[2].Text;
            var pass = valaszok[3].Text;
            var emil = valaszok[4].Text;
            var rs = new Data.RestService();
            RestApiModell vissza = await rs.RefreshDataAsync();*/

            /*var rs = new Data.RestService();
            rs.name = name;
            rs.name2 = name2;
            rs.code = code;
            rs.pass = pass;
            rs.emil = emil;
            RestApiModell vissza =rs.ReggiFutAsync();*/
            //var vissza = rs.RefreshDataAsync();


            //var valasz = new RestApiModell();


            //RestApiModell x =   GetJSON();
            /*RestApiModell ObjContactList = new RestApiModell();
            if (contactsJson != "")
            {
                //Converting JSON Array Objects into generic list  
                ObjContactList = JsonConvert.DeserializeObject<RestApiModell>(contactsJson);
            }-*/
            var aa = "aa";

        }
        public string name { get; internal set; }
        public string name2 { get; internal set; }
        public string code { get; internal set; }
        public string pass { get; internal set; }
        public string emil { get; internal set; }
        
        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            
            //
            var oldText = e.OldTextValue;
            var newText = e.NewTextValue;

            var inputBox = (Entry)sender;
            Boolean nyert = true;
            for (var i=0; i < valaszok.Count ; i++)
            {
                if (Length(valaszok[i].Text) > 0)
                {
                    Trace.WriteLine(valaszok[i].Text);
                    

                }
                if (Length(BTrim(valaszok[i].Text)) == 0)
                {

                    nyert = false;
                    //Debug.WriteLine("aa");
                    //Console.WriteLine("hellololllll");
                    //Debug.WriteLine(i);
                    //var ho = Length(BTrim(valaszok[i].Text));
                    //Debug.WriteLine(ho);
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
        
        private static void bazsiInit(StackLayout myLayout, UsersDataAccess adatBazis)
        {
            ///


            //SQLiteConnection conn = new SQLiteConnection();

            //UsersDataAccess adatBazis = new UsersDataAccess();
            Console.Write("aaaa1");
            var idd = adatBazis.SaveCogAzon(new Cogazon
            {
                uemail = "1",
                uname = "helloleo",
                upass = "1",
                userid = 1,
                usname = "1"
            });
            var idd2 = adatBazis.SaveCogAzon(new Cogazon
            {
                uemail = "12",
                uname = "helloleo",
                upass = "12",
                userid = 12,
                usname = "12"
            });
            Console.Write("aaaa2");
            //Cogazon mostadat = new Cogazon();
            var mostadat = adatBazis.GetCogAzonAsSern(idd - 1);
            if (mostadat is Cogazon)
            {
                var alfa = "aaaa";
            }
            IEnumerable<Cogazon> mostadat2 = adatBazis.GetCogAzonAsSern(idd - 1);
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
