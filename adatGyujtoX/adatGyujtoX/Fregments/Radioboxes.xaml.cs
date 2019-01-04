using adatGyujtoX.Modell;
using System;
using System.Collections.Generic;
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

            Label teszt = new Label();
            teszt.Text = "bibibi";
            myLayout.Children.Add(teszt);

            

        }
    }
}