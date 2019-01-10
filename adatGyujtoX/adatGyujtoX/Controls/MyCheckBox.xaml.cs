using adatGyujtoX.Modell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyCheckBox : ContentView
    {
        /*public event EventHandler IsCheckedChanged;
        public delegate void Ertesito();
        public  Ertesito ertesito;
        public delegate int Ertesito2(int alfa);
        public Ertesito2 ertesito2;
        public event EventHandler Ertesoto3;
        public event EventHandler<int> Ertesoto4;*/
        public event EventHandler<int> Clicked;

        Button button;
        Label label;
        private string _text;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                this._text = value;
                cbFresh();
            }
        }
        private Font _font;
        public Font font
        {
            get
            {
                return _font;
            }
            set
            {
                this._font = value;
                cbFresh();
            }
        }

        private void cbFresh()
        {
            //throw new NotImplementedException();
            button.Text = _text;
            button.Font = _font;
            label.Text = _text;
            label.Font = _font;
        }

        /*public static readonly BindableProperty IsCheckedProperty = 
            BindableProperty.Create(
                nameof(IsChecked), 
                typeof(bool), 
                typeof(MyCheckBox), 
                false, 
                BindingMode.TwoWay, 
                propertyChanged: OnIsCheckedChanged);*/
        public MyCheckBox ()
		{
			InitializeComponent ();
            
            button = new Button();
            //button.Text = Constans.bumbuc_false + "  " + _text;
            button.Text =  _text;
            button.HorizontalOptions = LayoutOptions.Start;
            //button.FontSize = "Large";
            button.Font = Font.SystemFontOfSize(NamedSize.Small);
            button.BackgroundColor = Color.Transparent;
            //button.Opacity = 1;
            button.Clicked += button_Clicked;

            //myLayout.Children.Add(button);

            /*StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.Beige;
            stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;*/
            
            label = new Label();
            label.Text = _text;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;
            label.Font = Font.SystemFontOfSize(NamedSize.Small);
            //label.WidthRequest=Constans.ScreenWidth-12;
           

            label.BackgroundColor = Color.Red;
            //label.BackgroundColor = Color.Transparent;
            //label.Clicked += button_Clicked;
            var label_tap = new TapGestureRecognizer();
            label_tap.Tapped += (sender, e) =>
            {
                //
                //  Do your work here.
                //
                Debug.WriteLine("volt tapi");
                Label button = (Label)sender;
                string eleje = button.Text;
                string eleje2 = Convert.ToString(eleje.ElementAt(0));
                string vege = eleje.Substring(1, eleje.Length - 1);
                if (eleje2 == Constans.bumbuc_true)
                {
                    //button.Text = Constans.bumbuc_false + vege;
                    //IsChecked = false;
                    Clicked.Invoke(this, 0);

                }
                else
                {
                    //button.Text = Constans.bumbuc_true + vege;
                    //IsChecked = true;
                    Clicked.Invoke(this, 1);
                }
            };
            label.GestureRecognizers.Add(label_tap);

            /*var l_tap = new TapGestureRecognizer();
            l_tap.Tapped += (sender, e) =>
            {
                //
                //  Do your work here.
                //
                Debug.WriteLine("volt tapi");
                Label button = label;
                string eleje = button.Text;
                string eleje2 = Convert.ToString(eleje.ElementAt(0));
                string vege = eleje.Substring(1, eleje.Length - 1);
                if (eleje2 == Constans.bumbuc_true)
                {
                    //button.Text = Constans.bumbuc_false + vege;
                    //IsChecked = false;
                    Clicked.Invoke(this, 0);

                }
                else
                {
                    //button.Text = Constans.bumbuc_true + vege;
                    //IsChecked = true;
                    Clicked.Invoke(this, 1);
                }
            };


            
            stackLayout.Children.Add(label);
            myLayout.Children.Add(stackLayout);*/
            myLayout.Children.Add(label);

            /*this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                command = new Command(() =>
                {
                    if (command != null)
                    {
                        if (Command.CanExecute(CommanParamater))
                            Command.Execute(CommanParamater);
                    }
                }
            });*/
            /*GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = _toggleCommand
            });*/
        }
        /*public EventHandler IsCheckedChanged
        {
            get { return null; }
            //set { _label="voltklikk"; }
        }*/
        private void button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string eleje = button.Text;
            string eleje2 = Convert.ToString(eleje.ElementAt(0));
            string vege = eleje.Substring(1, eleje.Length - 1);
            if (eleje2 == Constans.bumbuc_true)
            {
                //button.Text = Constans.bumbuc_false + vege;
                //IsChecked = false;
                Clicked.Invoke(this, 0);

            }
            else
            {
                //button.Text = Constans.bumbuc_true + vege;
                //IsChecked = true;
                Clicked.Invoke(this, 1);
            }
            /*var myertesito = ertesito;
            if (myertesito != null)
            {
                myertesito();
            }

            var myertesito2 = ertesito2;
            if (myertesito2 != null)
            {
                myertesito2(3);
            }*/


            //myertesito2?.Invoke("aaaa");
            // _toggleCommand = new Command(OnTappedCommand);

            //IsCheckedChanged += MyCheckBox_IsCheckedChanged1;

            /*var myErtesito3 = Ertesoto3;
            myErtesito3.Invoke(this,e);
            var myErtesito4 = Ertesoto4;
            myErtesito4.Invoke(this, 8);*/

            //Ertesoto3?.Invoke("aaa");


            //this.IsCheckedChanged?.Invoke(this, IsChecked);
            //MyCheckBox.IsCheckedChanged?.Invoke(MyCheckBox, IsChecked);
            Debug.WriteLine("nyomi");


        }

        /*private void MyCheckBox_IsCheckedChanged1(object sender, string e)
        {
            //hrow new NotImplementedException();
            
            //this.IsCheckedChanged?.Invoke(this, "valami volt");
            //this.IsCheckedChanged(this, "aaaa");
        }*/

        /*private void MyCheckBox_IsCheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.IsCheckedChanged?.Invoke(this, e);
        }*/

        /*public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }*/
        /*static async void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MyCheckBox checkbox)) return;
            //checkbox.IsCheckedChanged?.Invoke(checkbox, new TappedEventArgs((bool)IsChecked));
            
        }*/
        /*void OnTappedCommand(object obj)
        {
            
            //IsChecked = !IsChecked;
        }
        public void Dispose()
        {
            GestureRecognizers.Clear();
        }*/

        /*var forgetPassword_tap = new TapGestureRecognizer();
        forgetPassword_tap.Tapped += (s, e) =>
        {
            //
            //  Do your work here.
            //
        };
        forgetPasswordLabel.GestureRecognizers.Add(forgetPassword_tap);*/
        

    }
}