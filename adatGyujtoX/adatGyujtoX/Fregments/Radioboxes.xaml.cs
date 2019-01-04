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
        //string bumbuc_false = "\U0001F518";
        //string bumbuc_true = "\U000123FA";

        //string bumbuc_false = "\U000125CB";
        //string bumbuc_true = "\U000125C9";

        string bumbuc_false = "⚪";
        string bumbuc_true = "⚫";
        Color semiTransparentColor = new Color(0, 0, 0, 0.9);

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
            Button button = new Button();
            button.Text = bumbuc_true + " hello leo " + bumbuc_false;

            button.BackgroundColor = semiTransparentColor;
            //button.Opacity = 1;
            button.Clicked += button_Clicked;
            myLayout.Children.Add(button);

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

        private void button_Clicked(object sender, EventArgs e)
        {
            Button mostNyomi=(Button)sender;
            string eleje = mostNyomi.Text;
            string eleje2 = Convert.ToString(eleje.ElementAt(0));
            string vege = eleje.Substring(1,eleje.Length-1);
            if (eleje2 == bumbuc_false)
            {
                mostNyomi.Text = bumbuc_true + vege;
            }
            else
            {
                mostNyomi.Text = bumbuc_false + vege;
            }
            Debug.WriteLine("nyomi");


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