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
	public partial class TablesRadio : ContentView
	{
        public static readonly BindableProperty TextProprty =
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(TablesRadio),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((TablesRadio)bindable).lbl.Text = (string)newValue;
                }
                );
        public static readonly BindableProperty valaszdbProperty =
            BindableProperty.Create(
                "ValaszDB",
                typeof(int),
                typeof(TablesRadio),
                defaultValue:5,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var a = 2;
                    //((Kinyilo)bindable).textLabel.FontSize = (double)newValue;
                    //((Kinyilo)bindable).boxLabel.FontSize = (double)newValue;
                }
                );
        Label lbl = new Label();
        public TablesRadio ()
		{
			InitializeComponent ();
            var sor = new Grid();
            sor.Margin = new Thickness(2, 2, 2, 2);
            BoxView bwTop = new BoxView();
            bwTop.WidthRequest = 1;
            bwTop.BackgroundColor = Color.Black;
            bwTop.VerticalOptions = LayoutOptions.Fill;
            bwTop.HorizontalOptions= LayoutOptions.Fill;
            bwTop.Opacity = 0.01;
            //bw.VerticalOptions = LayoutOptions.Fill;
            sor.Children.Add(bwTop);

            sor.HorizontalOptions = LayoutOptions.FillAndExpand;
            sor.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            sor.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            for (var i=1; i<= ValaszDB; i++)
            {
                sor.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            lbl.Text = Text;
            //lbl.BackgroundColor = Color.Pink;
            sor.Children.Add(lbl);
            sor.Children.Add(bwTop);

            for (var i = 0; i < ValaszDB; i++)
            {
                RadioButton rb = new RadioButton();
                //rb.BackgroundColor = Color.Peru;
                rb.HorizontalOptions = LayoutOptions.Center;
                rb.VerticalOptions = LayoutOptions.Center;
                //sor.Children.Add(bwTop);
                BoxView bwTop2 = new BoxView();
                bwTop2.WidthRequest = 1;
                bwTop2.BackgroundColor = Color.Black;
                bwTop2.VerticalOptions = LayoutOptions.Fill;
                bwTop2.HorizontalOptions = LayoutOptions.Fill;
                bwTop2.Opacity = 0.01;
                //bw.VerticalOptions = LayoutOptions.Fill;
                sor.Children.Add(bwTop2, i + 1, 0);
                sor.Children.Add(rb,i+1,0);
            }
            
            myLayout.Children.Add(sor);


        }
        public string Text
        {
            set { SetValue(TextProprty, value); }
            get { return (string)GetValue(TextProprty); }
        }
        public int ValaszDB
        {
            set { SetValue(valaszdbProperty, value); }
            get { return (int)GetValue(valaszdbProperty); }
        }
    }
}