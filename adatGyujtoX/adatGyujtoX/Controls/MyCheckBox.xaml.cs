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
        public event EventHandler IsCheckedChanged;
        //ICommand _toggleCommand;
        public string _label;
        public string label
        {
            get
            {
                return _label;
            }
            set
            {
                this._label = value;
            }
        }

        public static readonly BindableProperty IsCheckedProperty = 
            BindableProperty.Create(
                nameof(IsChecked), 
                typeof(bool), 
                typeof(MyCheckBox), 
                false, 
                BindingMode.TwoWay, 
                propertyChanged: OnIsCheckedChanged);
        public MyCheckBox ()
		{
			InitializeComponent ();
            Button button = new Button();
            button.Text = Constans.bumbuc_false + "  " + _label;
            button.HorizontalOptions = LayoutOptions.Start;
            //button.FontSize = "Large";
            button.Font = Font.SystemFontOfSize(NamedSize.Small);
            button.BackgroundColor = Color.Transparent;
            //button.Opacity = 1;
            button.Clicked += button_Clicked;
            myLayout.Children.Add(button);
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
                button.Text = Constans.bumbuc_false + vege;
                IsChecked = false;

            }
            else
            {
                button.Text = Constans.bumbuc_true + vege;
                IsChecked = true;
            }

            // _toggleCommand = new Command(OnTappedCommand);
            
            this.IsCheckedChanged(this, IsChecked                );
            //this.IsCheckedChanged?.Invoke(this, IsChecked);
            //MyCheckBox.IsCheckedChanged?.Invoke(MyCheckBox, IsChecked);
            Debug.WriteLine("nyomi");


        }
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        static async void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MyCheckBox checkbox)) return;
            //checkbox.IsCheckedChanged?.Invoke(checkbox, new TappedEventArgs((bool)IsChecked));
            
        }
        /*void OnTappedCommand(object obj)
        {
            
            //IsChecked = !IsChecked;
        }
        public void Dispose()
        {
            GestureRecognizers.Clear();
        }*/
    }
}