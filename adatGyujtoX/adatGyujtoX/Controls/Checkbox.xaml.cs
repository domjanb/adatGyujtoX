using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Checkbox : ContentView
	{
        public static readonly BindableProperty TextProprty =
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(Checkbox),
                propertyChanged: (bindable,oldValue,newValue) => 
                {
                    ((Checkbox)bindable).textLabel.Text = (string)newValue;
                }
                );
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                "FontSize",
                typeof(double),
                typeof(Checkbox),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((Checkbox)bindable).textLabel.FontSize = (double)newValue;
                    ((Checkbox)bindable).boxLabel.FontSize = (double)newValue;
                }
                );
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                "IsChecked",
                typeof(bool),
                typeof(Checkbox),
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((Checkbox)bindable).boxLabel.Text = (bool)newValue ? "\u2611" : "\u2610";
                }
                );
        public event EventHandler<bool> CheckedChange;
        public Checkbox ()
		{
			InitializeComponent ();
            
		}
        public string Text
        {
            set { SetValue(TextProprty, value); }
            get { return (string)GetValue(TextProprty); }
        }
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }
        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
    }
}