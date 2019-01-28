﻿using SQLite;
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
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using adatGyujtoX.Modell;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Net;
using System.ComponentModel;
using adatGyujtoX.Fregments;


namespace adatGyujtoX
{
    public partial class MainPage : ContentPage
    {

        IDownloader downloader = DependencyService.Get<IDownloader>();
        IDisplay display = DependencyService.Get<IDisplay>();
        List<Entry> valaszok = new List<Entry>();
        //String[] vs;

        Button reggomb;
        private RestApiModell vissza;
        
        //private Button[] buttons;
        List<Button> listOfButtons = new List<Button>();
       
        public MainPage()
        {

            InitializeComponent();
            //var w = this.Width;
            //var w2 = this.WidthRequest;
            
            Constans.ScreenHeight=display.Height;
            Constans.ScreenWidth = display.Width;
            downloader.OnFileDownloaded += OnFileDownloaded;
            CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
            System.Diagnostics.Debug.WriteLine(
                "[DownloadManager] " + e.Action + 
                " -> New Items: " + (e.NewItems?.Count ?? 0) +
                " at " + e.NewStartingIndex +
                " || old items: " + (e.OldItems?.Count ?? 0) +
                " at " + e.OldStartingIndex

                );

            //Debug.WriteLine(Constans.myZipPath);
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
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
                    regForm.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
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
                    var regButton = new Button { Text = "Registration: OLLÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ 2 OLLÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ OLÉÉ" };
                    //regButton.IsVisible = false;
                    //regButton.Clicked +=await regButtonClickAsync;
                    regButton.Clicked += async (sender, e) =>
                    {
                        valaszok[0].Text = "33";
                        valaszok[1].Text = "33";
                        valaszok[2].Text = "33";
                        valaszok[3].Text = "33";
                        valaszok[4].Text = "33";
                        User user = new User();
                        user.user_name = valaszok[0].Text;
                        user.user_surnamed = valaszok[1].Text;
                        user.user_kod = valaszok[2].Text;
                        user.user_password = valaszok[3].Text;
                        user.user_emil = valaszok[4].Text;
                        var rs = new Data.RestService();
                        Debug.WriteLine(user);
                        vissza = await rs.Reggi(user);
                        Debug.WriteLine(vissza);
                        if (vissza.error)
                        {
                            var idd2 = adatBazis.SaveCogAzon(new Cogazon
                            {
                                uemail = user.user_emil,
                                uname = user.user_name,
                                upass = user.user_password,
                                userid =Convert.ToInt16(user.user_kod),
                                usname = user.user_surnamed
                            });

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
                            myLayout.Children.Remove(regButton);
                            var scroll = new ScrollView();
                            

                            var stack = new StackLayout();
                            scroll.Content = stack;
                            var regForm2 = new Grid();
                            regForm2.HorizontalOptions = LayoutOptions.Center;
                            //regForm2.BackgroundColor = Color.LightGray;
                            regForm2.Padding = 5;
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
                            regForm2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
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

                                var zipFileName = "kerdiv_" + vissza.kerdivadat[i].proj_id + "_" + vissza.kerdivadat[i].kerdiv1_ver;

                                var buttonM = new Button();
                                buttonM.Text = vissza.kerdivadat[i].kerdiv1_title;
                                regForm2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                                regForm2.Children.Add(buttonM, 1, i);
                                buttonM.IsVisible = false;
                                if (File.Exists(Constans.myZipPath + "/cognative/" + zipFileName + "/" + vissza.kerdivadat[i].kerdiv1_nev + ".json"))
                                {
                                    buttonM.IsVisible = true;
                                }
                                //buttonM.Clicked += ButtonM_Clicked;
                                buttonM.Clicked += ( aktButton,  eredmeny) =>
                                {
                                    Button button = (Button)aktButton;
                                    foreach (var itemT in Constans.myParam2)
                                    {
                                        if (Convert.ToString(button.Id) == itemT.Item1)
                                        {
                                            string ffilenev = itemT.Item3 + ".json";
                                            Constans.myFilePath = Path.Combine( Constans.myZipPath, "cognative", itemT.Item2);
                                            String ffile = Path.Combine(Constans.myZipPath ,"cognative",  itemT.Item2 , ffilenev);
                                            Debug.WriteLine("ffileneve: "+  ffile);
                                            //string jsonString = "";
                                            string jsonString = File.ReadAllText(ffile);
                                            jsonString = Constans.RemoveNewLines(jsonString);

                                            //using (var streamReader = new StreamReader(ffile))
                                            //{
                                            //    jsonString = streamReader.ReadToEnd();
                                                
                                            //}
                                            //Questions  responseObject = JsonConvert.DeserializeObject<Questions>(Path.Combine(jsonString));
                                            Questions responseObject = JsonConvert.DeserializeObject<Questions>(jsonString);
                                            Constans.aktQuestion = responseObject.questions.ElementAt(0);
                                            Constans.aktSurvey = responseObject;
                                            Constans.pageNumber = 1;
                                            //var a = "aa";
                                            Navigation.PushModalAsync(new FPage());
                                            break;

                                        }
                                    }
                                };

                                //Debug.WriteLine("button_id:" + buttonM.Id);
                                Constans.myParam.Add(Convert.ToString(buttonM.Id), zipFileName);
                                Constans.myParam2.Add(Tuple.Create(Convert.ToString(buttonM.Id), zipFileName, vissza.kerdivadat[i].kerdiv1_nev,idd));
                                
                                listOfButtons.Add(buttonM);



                                //Debug.WriteLine(Convert.ToDateTime(vissza.kerdivadat[i].kerdiv2_le));
                            }
                            Constans.kellZipIndex = 0;
                            foreach(var button in listOfButtons)
                            {
                                if (!button.IsVisible)
                                {
                                    foreach (var itemT in Constans.myParam2)
                                    {
                                        if (Convert.ToString(button.Id) == itemT.Item1)
                                        {
                                            var Url = Constans.downUrl + itemT.Item2 + ".zip";
                                            //DownloadFile2(Url);
                                            //downloader.DownloadFile(Url, "cognative");
                                            Constans.kellZip.Add(Url);

                                        }
                                    }

                                        
                                }
                            }
                            if (Constans.kellZip.Count > 0)
                            {
                                var aktUrl = Constans.kellZip.ElementAt(Constans.kellZipIndex);
                                downloader.DownloadFile(aktUrl, "cognative");
                                Constans.kellZipIndex++;
                            }

                            
                            /*string mostFile = "/kerdiv_1_1.zip";
                            Debug.WriteLine(Constans.myZipPath + "/" + Constans.myZipFile);
                            if (!File.Exists(Constans.myZipPath+ mostFile))
                            {
                                Debug.WriteLine("nem kell " + mostFile);
                                var Url = "http://qnr.cognative.hu/cogsurv" + mostFile;
                                DownloadFile2(Url);
                                //myDownloadFile(Url);
                                
                            }*/

                            Debug.WriteLine(Constans.myZipPath);
                            stack.Children.Add(regForm2);
                            myLayout.Children.Add(scroll);

                        }
                            //var aa = vissza.getError();
                            //var bb = vissza.getMessage();
                            var cc = vissza.message;
                        
                        //var visszatrue= vissza.Rootobject.error;
                        Debug.WriteLine("vlasz " + Convert.ToString(vissza));
                    }; 
                    reggomb = regButton;
                    
                    valaszok.Add( name);
                    valaszok.Add( name2);
                    valaszok.Add( code);
                    valaszok.Add(pass);
                    valaszok.Add(emil);
                    
                    //regForm.Children.Add(zeroC, 0, 0);
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
                    
                    //regForm.Children.Add(regButton, 1, 6);
                    //Grid.SetColumnSpan(regButton, 2);
                    //Grid.SetColumnSpan(regButton, 1);



                    
                    myLayout.Children.Add(regForm);
                    myLayout.Children.Add(regButton);
                    //ide jön a http reg
                }
            }

            bazsiInit(myLayout, adatBazis);

            Content = myLayout;
        }

        private void ButtonM_Clicked(Button sender, EventArgs e)
        {
            foreach (var itemT in Constans.myParam2)
            {
                if (Convert.ToString(sender.Id) == itemT.Item1)
                {

                    Questions responseObject = JsonConvert.DeserializeObject<Questions>(Path.Combine(Constans.myZipPath,"cognative",  itemT.Item3 + ".json"));
                    Constans.pageNumber = -1;
                    if (responseObject.survey_properties.skip_intro)
                    {
                        Constans.pageNumber = 0;
                    }
                    //var a = "aa";
                }
            }
                    
            
        }

        private void gombEllAll()
        {
            throw new NotImplementedException();
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
            IEnumerable<Cogazon> mostadat2 = adatBazis.GetCogAzonAsSern(idd - 1);
            /*if (mostadat is Cogazon)
            {
                var alfa = "aaaa";
            }
            
            if (mostadat2 is Cogazon)
            {
                var alfa2 = "aaaa";
            }*/
            
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

            /*button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new HelloXamlPage());
            };*/
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
        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            Debug.WriteLine(Constans.errorDuma);
            if (e.FileSaved)
            {
                //DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
                ExtractZipFile(Constans.myZipPath + "/cognative/" + e.ZipFileMentett, null, Constans.myZipPath + "/cognative/");
                for (var zipIndex = 0; zipIndex < Constans.kellZip.Count; zipIndex++)
                {
                    if (Constans.downUrl + e.ZipFileMentett == Constans.kellZip.ElementAt(zipIndex))
                    {
                        Constans.kellZip.Remove(Constans.downUrl + e.ZipFileMentett);
                        Constans.kellZipIndex--;
                        break;
                    }
                }
                

            }
            else
            {
                DisplayAlert("XF Downloader", "Error while saving the file", "Close");
            }
            if (Constans.kellZip.Count > 0 && Constans.kellZipIndex<=Constans.kellZip.Count)
            {
                var aktUrl = Constans.kellZip.ElementAt(Constans.kellZipIndex);
                downloader.DownloadFile(aktUrl, "cognative");
                ExtractZipFile(Constans.myZipPath + "/cognative/" + e.ZipFileMentett, null, Constans.myZipPath+"/cognative/");
                Constans.kellZipIndex++;
                foreach (var itemT in Constans.myParam2)
                {
                    if ((itemT.Item2 + ".zip") == e.ZipFileMentett)
                    {
                        if (File.Exists(Constans.myZipPath + "cognative/"+ itemT.Item2 + "/" + itemT.Item3 + ".json"))
                        {
                            foreach (var button in listOfButtons)
                            {
                                if (Convert.ToString(button.Id) == itemT.Item1)
                                {
                                    button.IsVisible = true;
                                }
                            }
                        }
                    }

                }
            }
        }
        
        public void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            int zipDarab = 0;
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                        zipDarab = zipDarab + 1;
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources

                }
            }
        }
        
    }

}
