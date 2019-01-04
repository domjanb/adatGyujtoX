using adatGyujtoX.Controls;
using adatGyujtoX.Modell;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace adatGyujtoX.Fregments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Radioboxes : ContentPage
	{
		public Radioboxes ()
		{
			InitializeComponent ();
            /*var myLayout = new StackLayout();

            var fejlecL = new StackLayout();
            fejlecL.BackgroundColor = Color.Aqua;
            fejlecL.HorizontalOptions = LayoutOptions.FillAndExpand;
            fejlecL.Padding = 20;

            var fejlecD = new Label();
            fejlecD.Text = "Cognative Touchpoint";
            fejlecD.HorizontalOptions = LayoutOptions.Center;

            fejlecL.Children.Add(fejlecD);

            myLayout.Children.Add(fejlecL);

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;

            myLayout.Children.Add(kerdes);
            Content = myLayout;*/

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myLayout.Children.Add(kerdes);

            myCheckbox cb = new myCheckbox();
            cb.Shape = Shape.Rectangle;
            cb.IsCheckedChanged += Cb_IsCheckedChanged;
            myLayout.Children.Add(cb);

            myCheckbox cb2 = new myCheckbox();
            cb2.Shape=Shape.Circle;
            cb2.IsCheckedChanged += Cb_IsCheckedChanged;
            myLayout.Children.Add(cb2);





        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("volt nyomi");
            //DisplayAlert("Continue ", "volt nyomi", "Cancel");
        }
        private void Cb_IsCheckedChanged(object sender, TappedEventArgs e)
        {
            if (e.Parameter.Equals(true))
            {
                Debug.WriteLine("valami volt - true");
            }
            else
            {
                Debug.WriteLine("valami volt - false");
            }
            

        }
    }
}